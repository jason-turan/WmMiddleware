using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.InventorySync.Models;
using WmMiddleware.InventorySync.Models.Generated;

namespace Middleware.Wm.InventorySync.Repository
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
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {

                var parameter = new
                {
                    inventorySyncProcessing.TransactionNumber,
                    inventorySyncProcessing.ReceivedDate,
                    inventorySyncProcessing.ManhattanDateCreated,
                    inventorySyncProcessing.ManhattanTimeCreated
                };

                connection.Open();
                connection.Execute("sp_InsertInventorySyncProcessing", parameter, commandType: CommandType.StoredProcedure);
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

        public InventorySyncStatus GetInventorySyncStatus(int transactionNumber)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var parameter = new
                {
                    TransactionNumber = transactionNumber
                };

                return connection.Query<InventorySyncStatus>("sp_GetInventorySyncStatus", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    
    }
}
