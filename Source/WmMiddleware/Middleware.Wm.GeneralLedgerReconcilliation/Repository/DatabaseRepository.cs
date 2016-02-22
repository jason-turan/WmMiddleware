using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public void InsertIntegrationInventoryAdjustment(DatabaseIntegrationsInventoryAdjustment databaseIntegrationsInventoryAdjustment)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseIntegrationsInventoryAdjustment);
            }
        }

        public void InsertPurchaseOrderHeaderInterface(DatabasePurchaseOrderHeaderInterface databaseIntegrationsInventoryAdjustment)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseIntegrationsInventoryAdjustment);
            }
        }

        public void InsertPurchaseOrderDetailInterface(DatabasePurchaseOrderDetailInterface databaseIntegrationsInventoryAdjustment)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseIntegrationsInventoryAdjustment);
            }
        }

        public IList<GeneralLedgerTransactionReasonCodeMap> GetGeneralLedgerTransactionReasonCodeMap()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                return connection.Query<GeneralLedgerTransactionReasonCodeMap>("sp_GetGeneralLedgerTransactionReasonCodeMap",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void InsertPixGeneralLedgerProcessing(PixGeneralLedgerProcessing pixGeneralLedgerProcessing)
        {

            const string insertInventorySyncProcessing = @"INSERT INTO [dbo].[ManhattanPerpetualInventoryTransferGeneralLedgerProcessing]
                                                            ([ManhattanPerpetualInventoryTransferId]
                                                            ,[ProcessedDate])
                                                            VALUES
                                                            (@ManhattanPerpetualInventoryTransferId
                                                            ,@ProcessedDate)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertInventorySyncProcessing, pixGeneralLedgerProcessing);
            }
        }
    }
}
