using System;
using System.Linq;
using System.Transactions;
using Dapper;
using Middleware.Jobs;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Pix.Models.Generated;
using WmMiddleware.Pix.Repository;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Pix
{
    public class PixJob : IPixJob
    {
        private readonly ILog _log;
        private readonly IJobRepository _jobRepository;
        private readonly ITransferControlRepository _transferControlRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public PixJob(ILog log, 
                      IJobRepository jobRepository, 
                      ITransferControlRepository transferControlRepository,
                      IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository)
        {
            _log = log;
            _jobRepository = jobRepository;
            _transferControlRepository = transferControlRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            bool allSucceeded = true;

            var pixRepository = new DataFileRepository<PerpetualInventoryTransfer>();
            
            var job = _jobRepository.GetJob(JobKey.Pix);

            var toProcess = _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria()
            {
                Processed = false,
                JobId = job.JobId,
                JobType = JobType.Outbound
            }).ToList();

            _log.Info("Found " + toProcess.Count() + " pix batches to process");

            foreach (var transferControl in toProcess)
            {
                try
                {
                    using (var transactionScope = new TransactionScope())
                    {
                        foreach (var file in transferControl.Files)
                        {
                            var pix = pixRepository.Get(file.FileLocation);
                            _perpetualInventoryTransferRepository.InsertPerpetualInventoryTransfer(pix.AsList());
                            _log.Debug("Inserted records from file " + file.FileLocation);
                        }

                        transferControl.ProcessedDate = DateTime.Now;
                        _transferControlRepository.UpdateTransferControl(transferControl);
                        transactionScope.Complete();
                        _log.Info("Outbound batch " + transferControl.BatchControlNumber + " completed.");
                    }
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal exception processing batch " + transferControl.BatchControlNumber, exception);
                    allSucceeded = false;
                }

                if (!allSucceeded)
                {
                    throw new Exception("At least one pix batch has failed.");
                }
            }
        }
    }
}
