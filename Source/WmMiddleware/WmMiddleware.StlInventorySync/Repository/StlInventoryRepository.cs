using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.StlInventorySync.Models;

namespace WmMiddleware.StlInventorySync.Repository
{
    public class StlInventoryRepository : IStlInventoryRepository
    {
        private readonly IInventorySyncRepository _inventorySyncRepository;

        public StlInventoryRepository(IInventorySyncRepository inventorySyncRepository)
        {
            _inventorySyncRepository = inventorySyncRepository;
        }

        public IEnumerable<StlInventory> GetLatestManhattanInventorySync()
        {
            var inventorySyncLatest = _inventorySyncRepository.FindManhattanInventorySync();

            return inventorySyncLatest.Select(inventorySync => new StlInventory(inventorySync)).ToList();
        }

        public void InsertStlInventory(IList<StlInventory> stlInventory)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(stlInventory);
            }
        }

    }
}
