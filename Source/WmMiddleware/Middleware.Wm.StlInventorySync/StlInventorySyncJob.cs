using System.Linq;
using System.Text;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.InventorySync.Models;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Repository;
using Middleware.Wm.StlInventorySync.Repository;
using Middleware.Wm.StlInventoryUpdate;
using Middleware.Wm.StlInventoryUpdate.Repository;

namespace Middleware.Wm.StlInventorySync
{
    public class StlInventorySyncJob : IUnitOfWork
    {
        private readonly ILog _log;
        //private readonly IStlInventoryRepository _stlInventoryRepository;
        private readonly IInventorySyncRepository _inventorySyncRepository;
        private readonly IStlInventoryUpdateRepository _stlInventoryUpdateRepository;
        private readonly IShipmentInventoryAdjustmentRepository _shipmentInventoryAdjustmentRepository;
        private readonly IPixInventoryAdjustmentRepository _pixInventoryAdjustmentRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public StlInventorySyncJob(ILog log, IInventorySyncRepository inventorySyncRepository,
            IStlInventoryUpdateRepository stlInventoryUpdateRepository, IShipmentInventoryAdjustmentRepository shipmentInventoryAdjustmentRepository,
            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository, IPixInventoryAdjustmentRepository pixInventoryAdjustmentRepository)
        {
            _log = log;
            //_stlInventoryRepository = stlInventory;
            _inventorySyncRepository = inventorySyncRepository;
            _stlInventoryUpdateRepository = stlInventoryUpdateRepository;
            _shipmentInventoryAdjustmentRepository = shipmentInventoryAdjustmentRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _pixInventoryAdjustmentRepository = pixInventoryAdjustmentRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            ////initialize update job to ensure outstanding PIX/Shipments are consumed before the sync
            //var stlInventoryUpdateJob = new StlInventoryUpdateJob(_log, 
            //                                                      _stlInventoryUpdateRepository, 
            //                                                      _shipmentInventoryAdjustmentRepository,
            //                                                      _perpetualInventoryTransferRepository, 
            //                                                      _pixInventoryAdjustmentRepository);
            
            ////execute StlInventoryUpdate job. 
            //stlInventoryUpdateJob.RunUnitOfWork("Stl Inventory Update");
            
            //var latestInventorySync = _stlInventoryRepository.GetLatestManhattanInventorySync().ToList();

            //if (latestInventorySync.Count > 0)
            //{
            //    using (var transactionScope = Scope.CreateTransactionScope())
            //    {
            //         _stlInventoryRepository.InsertStlInventory(latestInventorySync);

            //        _log.Debug("Inserted " + latestInventorySync.Count() + " records from latest InventorySync data");

            //        _inventorySyncRepository.SetAsProcessed(new InventorySyncProcessing
            //        {
            //            TransactionNumber = latestInventorySync.First().ManhattanInventorySyncTransactionNumber,
            //            ProcessedDate = latestInventorySync.First().InventoryDate
            //        });

            //        transactionScope.Complete();
            //    }

            //    var logBuilder = new StringBuilder();
            //    logBuilder.AppendLine("---AUDIT REPORT---");
            //    logBuilder.AppendLine("STATUS | SKU | QUANTITY");

            //    var auditEntries = _stlInventoryRepository.GetStlInventorySyncAudit();

            //    foreach (var entry in auditEntries)
            //    {
            //        logBuilder.AppendLine(string.Format("{0} | {1} | {2}", entry.Status, entry.Upc, entry.Quantity));
            //    }

            //    _log.Debug(logBuilder.ToString());

            //}
            //else
            //{
            //    _log.Debug("No sync data for StlInventory!!!");
            //}          
        }

    }
}
