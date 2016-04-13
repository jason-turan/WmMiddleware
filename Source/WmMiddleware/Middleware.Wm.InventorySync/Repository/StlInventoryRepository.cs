using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.InventorySync.Models;

namespace Middleware.Wm.InventorySync.Repository
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

            var inventoryDate = DateTime.Now;

            return inventorySyncLatest.Select(inventorySync => new StlInventory(inventoryDate, inventorySync)).ToList();
        }

        public void InsertStlInventory(IList<StlInventory> stlInventory)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(stlInventory);
            }
        }

        public IEnumerable<StlInventorySyncAudit> GetStlInventorySyncAudit()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<StlInventorySyncAudit>("sp_AuditStlInventory_Sync", commandType: CommandType.StoredProcedure);
            }
        }

    }
}
