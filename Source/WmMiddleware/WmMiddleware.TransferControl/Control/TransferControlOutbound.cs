using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Models.Generated;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Control
{
    public class TransferControlOutbound : ITransferControlOutbound
    {
        private readonly ITransferControlRepository _transferControlRepository;
        private readonly IConfigurationManager _configuration;
        private readonly ILog _log;
        private readonly IJobRepository _jobRepository;
        private readonly IFileIo _fileIo;

        public TransferControlOutbound(ITransferControlRepository transferControlRepository,
                                       IJobRepository jobRepository,
                                       IConfigurationManager configuration,
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

            var outboundFileDirectory = _configuration.GetKey<string>(ConfigurationKey.TransferControlOutboundFileDirectory);
            var masterControlFileName =_configuration.GetKey<string>(ConfigurationKey.TransferControlOutboundMasterControlFileName);
            var transferControlMasterRepository = new DataFileRepository<TransferControlMaster>();
            var controlFile = Path.Combine(outboundFileDirectory, masterControlFileName);

            if (!File.Exists(controlFile))
            {
                _log.Info("Outbound: No control file to process at " + controlFile);
                return true;
            }

            _log.Debug("Outbound: reading " + controlFile);

            var masterControlMapping = transferControlMasterRepository.Get(controlFile).ToList();

            var batches = masterControlMapping.Select(e => e.BatchControlNumber).Distinct().ToList();

            using (var transactionScope = new TransactionScope())
            {
                foreach (var batch in batches)
                {
                    try
                    {
                        var transferControl = CreateTransferControl(batch, masterControlMapping, outboundFileDirectory);
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

                MoveToProcessedFolder(masterControlFileName, controlFile);

                transactionScope.Complete();
            }

            return true;
        }

        private void MoveToProcessedFolder(string masterControlFileName, string controlFile)
        {
            var outboundProcessedFileDirectory = _configuration.GetKey<string>(ConfigurationKey.TransferControlOutboundFileProcessedDirectory);

            string destFileName = outboundProcessedFileDirectory +
                                  masterControlFileName +
                                  "_" +
                                  DateTime.Now.ToString("yyyyMMddHHmmss");

            _fileIo.Move(new FileInfo(controlFile), new FileInfo(destFileName));
        }

        private Models.TransferControl CreateTransferControl(string batch, List<TransferControlMaster> masterControlMapping, string outboundFileDirectory)
        {
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
