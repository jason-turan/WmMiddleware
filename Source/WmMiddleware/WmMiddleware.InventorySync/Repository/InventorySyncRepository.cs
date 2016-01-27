using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.InventorySync.Models;
using WmMiddleware.InventorySync.Models.Generated;

namespace WmMiddleware.InventorySync.Repository
{
    public class InventorySyncRepository : IInventorySyncRepository
    {
        public void InsertInventorySync(IList<ManhattanInventorySync> inventorySync)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(inventorySync);
            }
        }

        public IEnumerable<ManhattanInventorySync> FindManhattanInventorySync()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanInventorySync>("sp_FindManhattanInventorySync", commandType: CommandType.StoredProcedure);
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
            const string updateInventorySyncProcessing = @"UPDATE [dbo].[InventorySyncProcessing]
                                                            SET ProcessedDate = @ProcessedDate
                                                            WHERE TransactionNumber = @TransactionNumber";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(updateInventorySyncProcessing, inventorySyncProcessing);
            }
        }
    }
}
