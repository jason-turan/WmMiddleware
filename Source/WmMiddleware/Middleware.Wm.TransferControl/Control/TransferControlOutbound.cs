using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;

namespace Middleware.Wm.TransferControl.Control
{
    public class TransferControlOutbound : ITransferControlOutbound
    {
        private readonly ITransferControlRepository _transferControlRepository;
        private readonly ITransferControlConfigurationManager _configuration;
        private readonly ILog _log;
        private readonly IJobRepository _jobRepository;
        private readonly IFileIo _fileIo;

        public TransferControlOutbound(ITransferControlRepository transferControlRepository,
                                       IJobRepository jobRepository,
                                       ITransferControlConfigurationManager configuration,
                                       ILog log,
                                       IFileIo fileIo)
        {
            _log = log;
            _transferControlRepository = transferControlRepository;
            _configuration = configuration;
            _jobRepository = jobRepository;
            _fileIo = fileIo;
        }

        public bool Process()
        {
            bool success = true;

            string controlFile = GetControlFilePath();
           
            if (!File.Exists(controlFile))
            {
                _log.Info("Outbound: No control file to process at " + controlFile);
                return true;
            }

            _log.Debug("Outbound: reading " + controlFile);

            var manhattanMasterControl = MapTransforControlFromManhattanFile(controlFile);

            using (var transactionScope = Scope.CreateTransactionScope())
            {
                // process each unique batch by grouping batch control number
                foreach (var batch in manhattanMasterControl.Select(e => e.BatchControlNumber).Distinct().ToList())
                {
                    try
                    {
                        var transferControl = CreateTransferControl(batch, manhattanMasterControl);
                        var transferControlId = _transferControlRepository.InsertTransferControl(transferControl);
                        
                        _log.Debug("Outbound:Created transfer id " + transferControlId + " for batch " + batch);
                    }
                    catch (Exception exception)
                    {
                        _log.Exception("Outbound:Fatal exception processing batch " + batch, exception);
                        success = false;
                    }
                }

                if (!success) return false;

                MoveToProcessedFolder(controlFile);

                transactionScope.Complete();
            }

            return true;
        }

        private static List<TransferControlMaster> MapTransforControlFromManhattanFile(string controlFile)
        {
            var transferControlMasterRepository = new DataFileRepository<TransferControlMaster>();
            var masterControlMapping = transferControlMasterRepository.Get(controlFile).ToList();
            return masterControlMapping;
        }

        private string GetControlFilePath()
        {
            var outboundFileDirectory = _configuration.GetOutboundFileDirectory();
            var masterControlFileName = _configuration.GetOutboundMasterControlFilename();
            var controlFile = Path.Combine(outboundFileDirectory, masterControlFileName);
            return controlFile;
        }

        private void MoveToProcessedFolder(string controlFile)
        {
            var masterControlFileName = _configuration.GetOutboundMasterControlFilename();
            var outboundProcessedFileDirectory = _configuration.GetOutboundFileProcessedDirectory();

            string destFileName = outboundProcessedFileDirectory +
                                  masterControlFileName +
                                  "_" +
                                  DateTime.Now.ToString("yyyyMMddHHmmss");

            _fileIo.Move(new FileInfo(controlFile), new FileInfo(destFileName));
        }

        private Models.TransferControl CreateTransferControl(string batch, List<TransferControlMaster> masterControlMapping)
        {
            var outboundFileDirectory = _configuration.GetOutboundFileDirectory();
            
            var transferControl = new Models.TransferControl
            {
                BatchControlNumber = batch,
                Files = new List<TransferControlFile>(),
                ReceivedDate = DateTime.Now,
                JobId = DetermineJobId(batch, masterControlMapping)
            };

            foreach (var mapping in masterControlMapping)
            {
                if (mapping.BatchControlNumber == batch)
                {
                    transferControl.Files.Add(new TransferControlFile
                    {
                        FileLocation = Path.Combine(outboundFileDirectory, mapping.Filename)
                    });
                }
            }
            return transferControl;
        }

        private int DetermineJobId(string batch, IEnumerable<TransferControlMaster> masterControlMapping)
        {
            // get two character file type prefix embedded in the first file name for the batch
            // in cases of multiple files only one needs to be mapped to determine job id
            var firstFilePrefix = masterControlMapping.
                                        Where(m => m.BatchControlNumber == batch).
                                        Select(m => m.Filename.Substring(0, 2)).
                                        First();

            var jobId = _jobRepository.GetJobIdByFilePrefix(firstFilePrefix);

            if (!jobId.HasValue)
            {
                throw new NotSupportedException("Outbound: Cannot determine job id for file type " + 
                                                firstFilePrefix +
                                                " for batch " +
                                                batch);    
            }
            
            return jobId.Value;
        }
    }
}
