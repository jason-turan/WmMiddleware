using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Pix.Models;
using WmMiddleware.Pix.Models.Generated;
using System.Text;

namespace Middleware.Wm.Pix.Repository
{
    public class PerpetualInventoryTransferRepository : IPerpetualInventoryTransferRepository
    {
        public void InsertPerpetualInventoryTransfer(IList<ManhattanPerpetualInventoryTransfer> perpetualInventoryTransfer)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(perpetualInventoryTransfer);
            }
        }

        public IEnumerable<ManhattanPerpetualInventoryTransfer> FindPerpetualInventoryTransfers(PerpetualInventoryTransactionCriteria criteria)
        {
            var searchArguments = new DynamicParameters();

            if (!string.IsNullOrEmpty(criteria.TransactionType))
            {
                searchArguments.Add("@TransactionType", criteria.TransactionType, DbType.String);
            }

            if (!string.IsNullOrEmpty(criteria.TransactionType))
            {
                searchArguments.Add("@TransactionCode", criteria.TransactionCode, DbType.String);
            }

            if (!string.IsNullOrEmpty(criteria.ProcessType))
            {
                searchArguments.Add("@ProcessType", criteria.ProcessType, DbType.String);
            }

            if (!string.IsNullOrEmpty(criteria.PurchaseOrderNumber))
            {
                searchArguments.Add("@Ponumber", criteria.PurchaseOrderNumber, DbType.String);
            }
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanPerpetualInventoryTransfer>("sp_FindManhattanPerpetualInventoryTransfers",
                                                                             searchArguments,
                                                                             commandType: CommandType.StoredProcedure,
                                                                             commandTimeout: 120);
            }
        }

        public void InsertManhattanPerpetualInventoryTransferProcessing(int manhattanPerpetualInventoryProcessingId)
        {
            const string insertSql = @"INSERT INTO ManhattanPerpetualInventoryTransferProcessing(ManhattanPerpetualInventoryTransferId, ProcessedDate)
                                           VALUES(@ManhattanPerpetualInventoryTransferId, @ProcessedDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@ManhattanPerpetualInventoryTransferId", manhattanPerpetualInventoryProcessingId, DbType.Int32);
            parameters.Add("@ProcessedDate", DateTime.Now, DbType.DateTime);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Execute(insertSql, parameters);
            }
        }

        public void InsertManhattanPerpetualInventoryNotificationProcessing(int manhattanPerpetualInventoryProcessingId)
        {
            const string insertSql = @"INSERT INTO ManhattanPerpetualInventoryTransferNotificationProcessing(ManhattanPerpetualInventoryTransferId, ProcessedDate)
                                           VALUES(@ManhattanPerpetualInventoryTransferId, @ProcessedDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@ManhattanPerpetualInventoryTransferId", manhattanPerpetualInventoryProcessingId, DbType.Int32);
            parameters.Add("@ProcessedDate", DateTime.Now, DbType.DateTime);
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Execute(insertSql, parameters);
            }
        }


        public void InsertPixInventoryAdjustmentProcessing(IList<PixInventoryAdjustment> pixInventoryAdjustments)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var inventoryPixProcessingTable = new DataTable();

                inventoryPixProcessingTable.Columns.Add("ManhattanPerpetualInventoryTransferId");
                inventoryPixProcessingTable.Columns.Add("ManhattanDateCreated");
                inventoryPixProcessingTable.Columns.Add("ManhattanTimeCreated");

                foreach (var adj in pixInventoryAdjustments)
                {
                    inventoryPixProcessingTable.Rows.Add(adj.ManhattanPerpetualInventoryTransferId, adj.ManhattanDateCreated, adj.ManhattanTimeCreated);
                }

                var parameter = new
                {
                    InventoryPixProcessingTable = inventoryPixProcessingTable.AsTableValuedParameter("[dbo].[InventoryPixProcessingTable]")
                };

                connection.Open();
                connection.Execute("sp_InsertInventoryPixProcessing", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public bool HasPurchaseOrderBeenNotified(string poNumber)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var sqlSb = new StringBuilder();
                sqlSb.AppendLine("SELECT COUNT(*) FROM ManhattanPerptualInventoryTransferPurchaseOrderNotification WHERE");
                sqlSb.AppendLine("PurchaseOrderNumber = @PurchaseOrderNumber");
                var sql = sqlSb.ToString();
                var parameters = new DynamicParameters();
                parameters.Add("@PurchaseOrderNumber", poNumber, DbType.String);
                var poCount =(int) connection.ExecuteScalar(sql, parameters);
                return poCount > 0;
            }
        }

        public void InsertPurchaseOrderNotified(string poNumber)
        {
            const string insertSql = @"INSERT INTO ManhattanPerptualInventoryTransferPurchaseOrderNotification(PurchaseOrderNumber, NotificationDate)
                                           VALUES(@PurchaseOrderNumber, GetDate())";

            var parameters = new DynamicParameters();
            parameters.Add("@PurchaseOrderNumber", poNumber, DbType.String);            
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Execute(insertSql, parameters);
            }
        }
    }
}
