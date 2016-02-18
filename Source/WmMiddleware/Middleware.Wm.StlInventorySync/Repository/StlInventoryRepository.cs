using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.StlInventorySync.Models;

namespace Middleware.Wm.StlInventorySync.Repository
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
