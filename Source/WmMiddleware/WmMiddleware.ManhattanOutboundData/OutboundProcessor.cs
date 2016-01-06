using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using Middleware.Jobs;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.ManhattanOutboundData
{
    public abstract class OutboundProcessor : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IConfigurationManager _configurationManager;
        private readonly IFileIo _fileIo;
        private readonly IJobRepository _jobRepository;
        private readonly ITransferControlRepository _transferControlRepository;

        protected OutboundProcessor(ILog log, 
                                 IConfigurationManager configurationManager, 
                                 IFileIo fileIo, 
                                 IJobRepository jobRepository,
                                 ITransferControlRepository transferControlRepository)
        {
            _log = log;
            _configurationManager = configurationManager;
            _fileIo = fileIo;
            _jobRepository = jobRepository;
            _transferControlRepository = transferControlRepository;
        }

        protected abstract void ProcessFilesForBatch(TransferControlFile transferControlFile); 

        public void RunUnitOfWork(string jobKey)
        {
            bool allSucceeded = true;

            foreach (var transferControl in GetUnprocessedRecords(jobKey))
            {
                try
                {
                    using (var transactionScope = new TransactionScope())
                    {
                        foreach (var transferControlFile in transferControl.Files)
                        {
                            ProcessFilesForBatch(transferControlFile);
                        }
                
                        UpdateTransferControl(transferControl);

                        transactionScope.Complete();
                    }

                    MoveFilesToProcessed(transferControl.Files);
                    _log.Info("Outbound batch " + transferControl.BatchControlNumber + " completed.");
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal exception processing batch " + transferControl.BatchControlNumber, exception);
                    allSucceeded = false;
                }

                if (!allSucceeded)
                {
                    throw new Exception("At least one shipment batch has failed.");
                }
            }
        }

        protected void LogInsert(IEnumerable<IGeneratedFlatFile> items, TransferControlFile file)
        {
            _log.Debug("Inserted " + items.Count() + " records from file " + file.FileLocation);
        }

        private IEnumerable<TransferControl.Models.TransferControl> GetUnprocessedRecords(string jobKey)
        {
            var job = _jobRepository.GetJob(jobKey);

            var toProcess = _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria
            {
                Processed = false,
                JobId = job.JobId,
                JobType = JobType.Outbound
            }).ToList();

            _log.Info("Found " + toProcess.Count() + " outbound batches to process for " + jobKey);

            return toProcess;
        }

        private void UpdateTransferControl(TransferControl.Models.TransferControl transferControl)
        {
            transferControl.ProcessedDate = DateTime.Now;
            _transferControlRepository.UpdateTransferControl(transferControl);
        }

        private void MoveFilesToProcessed(IEnumerable<TransferControlFile> files)
        {
            var processedPath =
                _configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileProcessedDirectory);

            foreach (var transferControlFile in files)
            {
                var fileInfo = new FileInfo(transferControlFile.FileLocation);
                _fileIo.Move(fileInfo, new FileInfo(Path.Combine(processedPath, fileInfo.Name)));
            }
        }
    }
}
