using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.InventorySync.Models;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Outbound;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;
using WmMiddleware.InventorySync.Models.Generated;

namespace Middleware.Wm.InventorySync
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

            var pixRepository = new DataFileRepository<ManhattanInventorySync>();
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
