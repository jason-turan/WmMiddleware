using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Jobs.Models;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Common.Extensions;
using WmMiddleware.TransferControl.Configuration;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Models.Generated;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Control
{
    public class TransferControlInbound : ITransferControlInbound
    {
        private const string TransferType = "I00";
        private const string StatusFlag = "10";
        private readonly ITransferControlRepository _transferControlRepository;
        private readonly IManhattanFtp _manhattanFtp;
        private readonly ITransferControlConfigurationManager _configuration;
        private readonly ILog _log;
        private readonly IFileIo _fileIo;

        public TransferControlInbound(ITransferControlRepository transferControlRepository,
            IManhattanFtp manhattanFtp,
            ITransferControlConfigurationManager configuration,
            ILog log,
            IFileIo fileIo)
        {
            _log = log;
            _transferControlRepository = transferControlRepository;
            _configuration = configuration;
            _manhattanFtp = manhattanFtp;
            _fileIo = fileIo;
        }

        public bool Process()
        {
            bool allSucceeded = true;

            var transferControls =
                _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria
                {
                    Processed = false,
                    JobType = JobType.Inbound
                }).ToList();

            if (transferControls.Count == 0)
            {
                _log.Info("Inbound: No records to process");
                return true;
            }

            foreach (var transferControl in transferControls)
            {
                try
                {
                    var fileList = new List<TransferControlMaster>();

                    foreach (var file in transferControl.Files)
                    {
                        // each file of the batch gets its own row
                        fileList.Add(UploadFile(file, transferControl));
                    }

                    AppendMasterControl(fileList, transferControl);
                }
                catch (Exception exception)
                {
                    _log.Exception("Inbound : Fatal exception processing batch " +
                                   transferControl.BatchControlNumber, exception);
                    allSucceeded = false;
                }
            }

            return allSucceeded;
        }

        private TransferControlMaster UploadFile(TransferControlFile file,
                                                 Models.TransferControl transferControl)
        {
            var fileInfo = new FileInfo(file.FileLocation);

            var master = new TransferControlMaster
            {
                BatchControlNumber = transferControl.BatchControlNumber,
                TransferType = TransferType,
                Library = _configuration.GetInboundFtpLocation(),
                Filename = fileInfo.Name,
                Member = fileInfo.Name,
                StatusFlag = StatusFlag,
                DateCreated = DateTime.Now.ToManhattanDate(),
                TimeCreated = DateTime.Now.ToManhattanTime(),
                UserId = _configuration.GetInboundFtpUsername(),
            };

            _log.Debug("Inbound : processing batch " +
                       transferControl.BatchControlNumber +
                       " file " +
                       fileInfo.FullName);

            FtpUploadFile(fileInfo);

            return master;
        }

        private void AppendMasterControl(IEnumerable<TransferControlMaster> files,
                                          Models.TransferControl transferControl)
        {
            try
            {
                var transferControlWriter = new DataFileRepository<TransferControlMaster>();

                WriteFile(transferControlWriter, files);

                FtpAppendTransferControl();

                transferControl.ProcessedDate = DateTime.Now;
                _transferControlRepository.UpdateTransferControl(transferControl);

                MoveTransferControlMasterToProcessedFolder();
            }
            catch (Exception exception)
            {
                _log.Exception("Inbound : Failure transmitting outbound master control file ", exception);
                throw;
            }
        }

        private void WriteFile(DataFileRepository<TransferControlMaster> transferControlWriter,
                               IEnumerable<TransferControlMaster> masters)
        {
            var masterControlFileName = _configuration.GetInboundMasterControlFilename();
            var inboundFileDirectory = _configuration.GetInboundFileDirectory();

            transferControlWriter.Save(masters, Path.Combine(inboundFileDirectory, masterControlFileName));
        }

        private void FtpUploadFile(FileInfo fileInfo)
        {
            var enableFtpTransmission = _configuration.IsFtpEnabled();

            if (!enableFtpTransmission)
            {
                return;
            }

            _manhattanFtp.UploadInboundFile(fileInfo);

            MoveInboundFileToProcessedFolder(fileInfo);
        }

        private void MoveInboundFileToProcessedFolder(FileInfo fileInfo)
        {
            var processedPath = _configuration.GetInboundFileProcessedDirectory();

            _fileIo.Move(fileInfo, new FileInfo(Path.Combine(processedPath, fileInfo.Name)));
        }

        private void FtpAppendTransferControl()
        {
            var enableFtpTransmission = _configuration.IsFtpEnabled();

            if (!enableFtpTransmission)
            {
                return;
            }

            var masterControlFile = GetMasterControlFilePath();

            _manhattanFtp.AppendInboundMasterControl(masterControlFile);
        }

        private FileInfo GetMasterControlFilePath()
        {
            var masterControlFileName = _configuration.GetInboundMasterControlFilename();
            var inboundFileDirectory = _configuration.GetInboundFileDirectory();
            var masterControlFile = new FileInfo(inboundFileDirectory + masterControlFileName);
            return masterControlFile;
        }

        private void MoveTransferControlMasterToProcessedFolder()
        {
            var masterControlFile = GetMasterControlFilePath();

            var processedPath = _configuration.GetInboundFileProcessedDirectory();

            _fileIo.Move(masterControlFile,
                new FileInfo(Path.Combine(processedPath, masterControlFile.Name + DateTime.Now.ToString("yyyyMMddHHmmss"))));
        }
    }
}
