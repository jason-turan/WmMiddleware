using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.InventorySync.Models;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Outbound;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Repository;
using Middleware.Wm.StlInventoryUpdate;
using Middleware.Wm.StlInventoryUpdate.Repository;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;
using WmMiddleware.InventorySync.Models.Generated;

namespace Middleware.Wm.InventorySync
{
    public class InventorySyncJob : OutboundProcessor
    {
        private readonly ILog _log;
        private readonly IInventorySyncRepository _inventorySyncRepository;

        private readonly IStlInventoryRepository _stlInventoryRepository;
        private readonly IStlInventoryUpdateRepository _stlInventoryUpdateRepository;
        private readonly IShipmentInventoryAdjustmentRepository _shipmentInventoryAdjustmentRepository;
        private readonly IPixInventoryAdjustmentRepository _pixInventoryAdjustmentRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public InventorySyncJob(ILog log,
            IConfigurationManager configurationManager,
            IJobRepository jobRepository,
            ITransferControlRepository transferControlRepository,
            IInventorySyncRepository inventorySyncRepository,
            IFileIo fileIo,
            ITransferControlConfigurationManager transferControlConfigurationManager,
            IStlInventoryRepository stlInventoryRepository,
            IStlInventoryUpdateRepository stlInventoryUpdateRepository, 
            IShipmentInventoryAdjustmentRepository shipmentInventoryAdjustmentRepository,
            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository, 
            IPixInventoryAdjustmentRepository pixInventoryAdjustmentRepository)
            : base(log, configurationManager, fileIo, jobRepository, transferControlRepository, transferControlConfigurationManager)
        {
            _inventorySyncRepository = inventorySyncRepository;
            _stlInventoryRepository = stlInventoryRepository;
            _stlInventoryUpdateRepository = stlInventoryUpdateRepository;
            _shipmentInventoryAdjustmentRepository = shipmentInventoryAdjustmentRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _pixInventoryAdjustmentRepository = pixInventoryAdjustmentRepository;
            _log = log;
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

            //1) Load the I5 sync file into our RAW Table.
            _inventorySyncRepository.InsertInventorySync(inventorySync);

            if (inventorySync.Count > 0)
                _inventorySyncRepository.SetAsReceived(new InventorySyncProcessing
                {
                    TransactionNumber = inventorySync.First().TransactionNumber,
                    ReceivedDate = DateTime.Now
                });

            LogInsert(inventorySync, transferControlFile);

            //2) Stl Inventory Update - Clean PIX/Shipments before loading the sync file.
            var stlInventoryUpdateJob = new StlInventoryUpdateJob(_log,
                                                                  _stlInventoryUpdateRepository,
                                                                  _shipmentInventoryAdjustmentRepository,
                                                                  _perpetualInventoryTransferRepository,
                                                                  _pixInventoryAdjustmentRepository);

            stlInventoryUpdateJob.RunUnitOfWork("Stl Inventory Update");


            //3) Load the Sync data into Stl Inventory Table. 
            var latestManhattanInventorySync = _stlInventoryRepository.GetLatestManhattanInventorySync().ToList();

            if (latestManhattanInventorySync.Count > 0)
            {
                using (var transactionScope = Scope.CreateTransactionScope())
                {
                    _stlInventoryRepository.InsertStlInventory(latestManhattanInventorySync);

                    _log.Debug("Inserted " + latestManhattanInventorySync.Count() + " records from latest InventorySync data");

                    _inventorySyncRepository.SetAsProcessed(new InventorySyncProcessing
                    {
                        TransactionNumber = latestManhattanInventorySync.First().ManhattanInventorySyncTransactionNumber,
                        ProcessedDate = latestManhattanInventorySync.First().InventoryDate
                    });

                    transactionScope.Complete();
                }

                var logBuilder = new StringBuilder();
                logBuilder.AppendLine("---AUDIT REPORT---");

                var auditEntries = _stlInventoryRepository.GetStlInventorySyncAudit().ToList();
                if (auditEntries.Count > 0)
                {
                    logBuilder.AppendLine("STATUS | SKU | QUANTITY");

                    foreach (var entry in auditEntries)
                    {
                        logBuilder.AppendLine(string.Format("{0} | {1} | {2}", entry.Status, entry.Upc, entry.Quantity));
                    }
                }
                else
                {
                    logBuilder.AppendLine("SYNC MATCHES CURRENT INVENTORY");
                }
                _log.Debug(logBuilder.ToString());

            }
            else
            {
                _log.Debug("No sync data for StlInventory!!!");
            }

        }
    }
}
