using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

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

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanPerpetualInventoryTransfer>("sp_FindManhattanPerpetualInventoryTransfers", searchArguments, commandType: CommandType.StoredProcedure);
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
    }
}
