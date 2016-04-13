using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Jobs.Models;
using Middleware.Log;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Ftp;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;

namespace Middleware.Wm.TransferControl.Control
{
    public class TransferControlInbound : ITransferControlInbound
    {
        private const string ManhattanTransferType = "I00";
        private const string AuroraTransferType = "OT2";
        private const string StatusFlag = "10";
        private const string AuoraProcessCodeForWarehouse = "1045"; // this tells Aurora to process co 10, whse 45
        private const decimal AuroraPriority = (decimal) 900.00;

        private readonly ITransferControlRepository _transferControlRepository;
        private readonly IMainframeFtp _manhattanFtp;
        private readonly ITransferControlConfigurationManager _configuration;
        private readonly ILog _log;
        private readonly IFileIo _fileIo;

        public TransferControlInbound(ITransferControlRepository transferControlRepository,
            IMainframeFtp manhattanFtp,
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
                    JobType = _configuration.GetInboundJobType(),

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

                    foreach (var file in transferControl.Files.OrderByDescending(o => o.FileLocation))
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
                TransferType = ManhattanTransferType,
                Library = _configuration.GetInboundFtpLocation(),
                Filename = fileInfo.Name,
                Member = fileInfo.Name,
                StatusFlag = StatusFlag,
                DateCreated = DateTime.Now.ToMainframeDate(),
                TimeCreated = DateTime.Now.ToMainframeTime(),
                UserId = _configuration.GetInboundFtpUsername(),
            };

            if (_configuration.GetInboundJobType() == JobType.AuroraInbound)
            {
                ProcessAuroraTransferControl(transferControl, master);
            }

            _log.Debug("Inbound : processing batch " +
                       transferControl.BatchControlNumber +
                       " file " +
                       fileInfo.FullName);

            FtpUploadFile(fileInfo);

            return master;
        }

        private static void ProcessAuroraTransferControl(Models.TransferControl transferControl, TransferControlMaster master)
        {
            master.TransferType = AuroraTransferType;
            master.Priority = AuroraPriority;
            master.CustomRecordExpansionField = AuoraProcessCodeForWarehouse;
            master.DateLastModified = DateTime.Now.ToMainframeDate();
            master.TimeLastModified = DateTime.Now.ToMainframeTime();
            if (transferControl.ReceivedDate != null)
            {
                master.BeginDate = transferControl.ReceivedDate.Value.ToMainframeDate();
                master.BeginTime = transferControl.ReceivedDate.Value.ToMainframeTime();
            }
            master.EndDate = DateTime.Now.ToMainframeDate();
            master.EndTime = DateTime.Now.ToMainframeTime();
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

            transferControlWriter.Save(masters.OrderByDescending(o => o.Filename), Path.Combine(inboundFileDirectory, masterControlFileName));
        }

        private void FtpUploadFile(FileInfo fileInfo)
        {
            var enableFtpTransmission = _configuration.IsFtpEnabled();

            if (!enableFtpTransmission)
            {
                _log.Warning("FTP upload is not enabled.  File " + fileInfo.FullName + " was NOT sent to host.");
                return;
            }

            _manhattanFtp.UploadInboundFile(fileInfo, _configuration.GetInboundFtpLocation());

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

            _manhattanFtp.AppendInboundMasterControl(masterControlFile,
                                                     _configuration.GetInboundMasterFileFtpLocation(), 
                                                     _configuration.GetInboundMasterControlFilename());
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
