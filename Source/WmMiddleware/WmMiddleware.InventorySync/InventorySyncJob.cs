﻿using System.Linq;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.InventorySync
{
    public class InventorySyncJob : OutboundProcessor, IInventorySyncJob
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

        protected override void ProcessFilesForBatch(TransferControlFile transferControlFile)
        {
            var pixRepository = new DataFileRepository<Models.Generated.InventorySync>();
            var inventorySync = pixRepository.Get(transferControlFile.FileLocation).ToList();
            _inventorySyncRepository.InsertInventorySync(inventorySync);
            LogInsert(inventorySync, transferControlFile);
        }
    }
}
