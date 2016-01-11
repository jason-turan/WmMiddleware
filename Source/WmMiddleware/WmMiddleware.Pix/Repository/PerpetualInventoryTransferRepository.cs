using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

namespace WmMiddleware.Pix.Repository
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
            var selectTransferControlFileSql = @"SELECT mpit.* 
                                                 FROM ManhattanPerpetualInventoryTransfer mpit
                                                 LEFT JOIN ManhattanPerpetualInventoryTransferProcessing mpitp
                                                    ON mpit.ManhattanPerpetualInventoryTransferId = mpitp.ManhattanPerpetualInventoryTransferId
                                                 WHERE TransactionType = @TransactionType
                                                 AND TransactionCode = @TransactionCode";

            var searchArguments = new DynamicParameters();
            
            if (criteria.Processed.HasValue)
            {
                if (criteria.Processed.Value)
                {
                    selectTransferControlFileSql = selectTransferControlFileSql + " AND mpitp.ProcessingId IS NOT NULL";
                }
                else
                {
                    selectTransferControlFileSql = selectTransferControlFileSql + " AND mpitp.ProcessingId IS NULL";
                }
            }

            searchArguments.Add("@TransactionType", criteria.TransactionType, DbType.String);
            searchArguments.Add("@TransactionCode", criteria.TransactionCode, DbType.String);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanPerpetualInventoryTransfer>(selectTransferControlFileSql, searchArguments);
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
    }
}
