using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Jobs.Models;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Common.Extensions;
using WmMiddleware.Configuration;
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
        private readonly IConfigurationManager _configuration;
        private readonly ILog _log;
        private readonly IFileIo _fileIo;

        public TransferControlInbound(ITransferControlRepository transferControlRepository,
            IManhattanFtp manhattanFtp,
            IConfigurationManager configuration,
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
                    var fileList = new List<TransferControlMaster>();  // each file of the batch gets its own row

                    foreach (var file in transferControl.Files)
                    {
                        UploadFile(file, transferControl, fileList);
                    }

                    var appendMasterControlSuccess = AppendMasterControl(fileList, transferControl);

                    if (!appendMasterControlSuccess)
                    {
                        allSucceeded = false;
                    }
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

        private void UploadFile(TransferControlFile file,
                                                Models.TransferControl transferControl,
                                                ICollection<TransferControlMaster> fileList)
        {
            var fileInfo = new FileInfo(file.FileLocation);

            var master = new TransferControlMaster
            {
                BatchControlNumber = transferControl.BatchControlNumber,
                TransferType = TransferType,
                Library = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFtpLocation),
                Filename = fileInfo.Name,
                Member = fileInfo.Name,
                StatusFlag = StatusFlag,
                DateCreated = DateTime.Now.ToManhattanDate(),
                TimeCreated = DateTime.Now.ToManhattanTime(),
                UserId = _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpUserName),
            };

            _log.Debug("Inbound : processing batch " +
                       transferControl.BatchControlNumber +
                       " file " +
                       fileInfo.FullName);

            FtpUploadFile(fileInfo);

            fileList.Add(master);
        }

        private bool AppendMasterControl(IEnumerable<TransferControlMaster> files,
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
                return false;
            }
            return true;
        }

        private void WriteFile(DataFileRepository<TransferControlMaster> transferControlWriter,
                               IEnumerable<TransferControlMaster> masters)
        {
            var masterControlFileName =
                _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
            var inboundFileDirectory =
                _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);

            transferControlWriter.Save(masters, Path.Combine(inboundFileDirectory, masterControlFileName));
        }

        private void FtpUploadFile(FileInfo fileInfo)
        {
            var enableFtpTransmission = _configuration.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable);

            if (!enableFtpTransmission)
            {
                return;
            }

            _manhattanFtp.UploadInboundFile(fileInfo);

            MoveInboundFileToProcessedFolder(fileInfo);
        }

        private void MoveInboundFileToProcessedFolder(FileInfo fileInfo)
        {
            var processedPath =
                _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory);

            _fileIo.Move(fileInfo, new FileInfo(Path.Combine(processedPath, fileInfo.Name)));
        }

        private void FtpAppendTransferControl()
        {
            var enableFtpTransmission = _configuration.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable);

            if (!enableFtpTransmission)
            {
                return;
            }

            var masterControlFile = GetMasterControlFilePath();

            _manhattanFtp.AppendInboundMasterControl(masterControlFile);
        }

        private FileInfo GetMasterControlFilePath()
        {
            var masterControlFileName =
                _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
            var inboundFileDirectory = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);
            var masterControlFile = new FileInfo(inboundFileDirectory + masterControlFileName);
            return masterControlFile;
        }

        private void MoveTransferControlMasterToProcessedFolder()
        {
            var masterControlFile = GetMasterControlFilePath();

            var processedPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory);

            _fileIo.Move(masterControlFile,
                new FileInfo(Path.Combine(processedPath, masterControlFile.Name + DateTime.Now.ToString("yyyyMMddHHmmss"))));
        }
    }
}
