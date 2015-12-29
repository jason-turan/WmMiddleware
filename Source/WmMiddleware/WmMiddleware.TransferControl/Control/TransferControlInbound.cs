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
            bool success = true;

            var enableFtpTransmission = _configuration.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable);

            var masters = new List<TransferControlMaster>();
            var transferControlMaster = new DataFileRepository<TransferControlMaster>();

            var unprocessedTransferControls =
                _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria
                {
                    Processed = false,
                    JobType = JobType.Inbound
                }).ToList();

            if (unprocessedTransferControls.Count == 0)
            {
                _log.Info("Inbound: No records to process");
                return true;
            }

            foreach (var transferControl in unprocessedTransferControls)
            {
                try
                {
                    foreach (var file in transferControl.Files)
                    {
                        ProcessTransferControlFile(file, 
                                                   transferControl, 
                                                   enableFtpTransmission, 
                                                   masters);
                    }

                    transferControl.ProcessedDate = DateTime.Now;
                }
                catch (Exception exception)
                {
                    _log.Exception("Inbound : Fatal exception processing batch " +
                                   transferControl.BatchControlNumber, exception);
                    success = false;
                }
            }

            if (masters.Count <= 0 || !success) return success;

            return ProcessMasterControl(transferControlMaster, 
                                        masters, 
                                        enableFtpTransmission, 
                                        unprocessedTransferControls);
        }

        private void ProcessTransferControlFile(TransferControlFile file, Models.TransferControl transferControl,
            bool enableFtpTransmission, List<TransferControlMaster> masters)
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

            FtpInboundTransferControlFile(enableFtpTransmission, fileInfo);

            masters.Add(master);
        }

        private bool ProcessMasterControl(DataFileRepository<TransferControlMaster> transferControlMaster, 
                                          IEnumerable<TransferControlMaster> masters, bool enableFtpTransmission,
                                          IEnumerable<Models.TransferControl> unprocessedTransferControls)
        {
            try
            {
                var masterControlFileName =
                    _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
                var inboundFileDirectory =
                    _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);

                transferControlMaster.Save(masters, Path.Combine(inboundFileDirectory, masterControlFileName));
                FtpInboundTransferControl(enableFtpTransmission, unprocessedTransferControls);
            }
            catch (Exception exception)
            {
                _log.Exception("Inbound : Failure transmitting outbound master control file ", exception);
                return false;
            }
            return true;
        }

        private void FtpInboundTransferControlFile(bool enableFtpTransmission, FileInfo fileInfo)
        {
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

        private void FtpInboundTransferControl(bool enableFtpTransmission,
            IEnumerable<Models.TransferControl> unprocessedTransferControls)
        {
            if (!enableFtpTransmission)
            {
                return;
            }

            var masterControlFileName = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
            var inboundFileDirectory = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);
            var masterControlFile = new FileInfo(inboundFileDirectory + masterControlFileName);

            _manhattanFtp.AppendInboundMasterControl(masterControlFile);

            foreach (var transferControl in unprocessedTransferControls)
            {
                _transferControlRepository.UpdateTransferControl(transferControl);
            }

            var processedPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory);

            _fileIo.Move(masterControlFile, 
                         new FileInfo(Path.Combine(processedPath, masterControlFile.Name + DateTime.Now.ToString("yyyyMMddHHmmss"))));
        }
    }
}
