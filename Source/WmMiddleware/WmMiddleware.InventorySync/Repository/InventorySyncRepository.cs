using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;

namespace WmMiddleware.InventorySync.Repository
{
    public class InventorySyncRepository : IInventorySyncRepository
    {
        public void InsertInventorySync(IList<Models.Generated.InventorySync> inventorySync)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(inventorySync);
            }
        }
    }
}
