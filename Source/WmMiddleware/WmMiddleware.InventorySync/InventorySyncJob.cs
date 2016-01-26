using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.InventorySync.Models;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.InventorySync
{
    public class InventorySyncJob : OutboundProcessor
    {
        private readonly IInventorySyncRepository _inventorySyncRepository;

        public InventorySyncJob(ILog log, 
                                IConfigurationManager configurationManager,
                                IJobRepository jobRepository, 
                                ITransferControlRepository transferControlRepository,
                                IInventorySyncRepository inventorySyncRepository,
                                IFileIo fileIo)
            : base(log, configurationManager, fileIo, jobRepository, transferControlRepository)
        {
            _inventorySyncRepository = inventorySyncRepository;
        }

        protected override void ProcessFiles(ICollection<TransferControlFile> transferControlFiles)
        {
            if (transferControlFiles.Count != 1)
            {
                throw new ArgumentOutOfRangeException("transferControlFiles", "Expected one file, found " + transferControlFiles.Count);
            }

            var transferControlFile = transferControlFiles.First();

            var pixRepository = new DataFileRepository<Models.Generated.ManhattanInventorySync>();
            var inventorySync = pixRepository.Get(transferControlFile.FileLocation).ToList();
            _inventorySyncRepository.InsertInventorySync(inventorySync);

            if (inventorySync.Count > 0)
                _inventorySyncRepository.SetAsReceived(new InventorySyncProcessing
                {
                    TransactionNumber = inventorySync.First().TransactionNumber, 
                    ReceivedDate = DateTime.Now
                } );

            LogInsert(inventorySync, transferControlFile);

        }
    }
}
