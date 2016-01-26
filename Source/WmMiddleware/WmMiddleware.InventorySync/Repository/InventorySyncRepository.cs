using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.InventorySync.Models;

namespace WmMiddleware.InventorySync.Repository
{
    public class InventorySyncRepository : IInventorySyncRepository
    {
        public void InsertInventorySync(IList<Models.Generated.ManhattanInventorySync> inventorySync)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(inventorySync);
            }
        }

        public void SetAsReceived(InventorySyncProcessing inventorySyncProcessing)
        {
            const string insertInventorySyncProcessing = @"INSERT INTO [dbo].[InventorySyncProcessing]
                                                            ([TransactionNumber]
                                                            ,[ReceivedDate]
                                                            ,[ProcessedDate])
                                                            VALUES
                                                            (@TransactionNumber
                                                            ,@ReceivedDate
                                                            ,@ProcessedDate)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertInventorySyncProcessing, inventorySyncProcessing);
            }
        }

        public void SetAsProcessed(InventorySyncProcessing inventorySyncProcessing)
        {
            const string insertInventorySyncProcessing = @"UPDATE [dbo].[InventorySyncProcessing]
                                                            SET ProcessedDate = @ProcessedDate
                                                            WHERE InventorySyncProcessingId = @InventorySyncProcessingId";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertInventorySyncProcessing, inventorySyncProcessing);
            }
        }
    }
}
