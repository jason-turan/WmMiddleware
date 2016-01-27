using System.Linq;
using System.Transactions;
using Middleware.Jobs;
using MiddleWare.Log;
using WmMiddleware.InventorySync.Models;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.StlInventorySync.Repository;

namespace WmMiddleware.StlInventorySync
{
    public class StlInventorySyncJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IStlInventoryRepository _stlInventoryRepository;
        private readonly IInventorySyncRepository _inventorySyncRepository;

        public StlInventorySyncJob(ILog log, IStlInventoryRepository stlInventory, IInventorySyncRepository inventorySyncRepository)
        {
            _log = log;
            _stlInventoryRepository = stlInventory;
            _inventorySyncRepository = inventorySyncRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            //TODO: Need to complete the following. 
            //step 1) - Ensure StlInventoryUpdate job is not running.
            //step 2) - Execute StlInventoryUpdate job to ensure all PIX/Shipments are accounted for before Inventory Sync. 

            var latestInventorySync = _stlInventoryRepository.GetLatestManhattanInventorySync().ToList();

            if (latestInventorySync.Count > 0)
            {
                using (var transactionScope = new TransactionScope())
                {
                     _stlInventoryRepository.InsertStlInventory(latestInventorySync);

                    _log.Debug("Inserted " + latestInventorySync.Count() + " records from latest InventorySync data");

                    _inventorySyncRepository.SetAsProcessed(new InventorySyncProcessing
                    {
                        TransactionNumber = latestInventorySync.First().ManhattanInventorySyncTransactionNumber,
                        ProcessedDate = latestInventorySync.First().InventoryDate
                    });          
                
                    transactionScope.Complete();
                }

            }
            else
            {
                _log.Debug("No sync data for StlInventory!!!");
            }          
        }

    }
}
