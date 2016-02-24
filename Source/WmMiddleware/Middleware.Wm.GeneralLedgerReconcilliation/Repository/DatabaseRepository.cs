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

        public void InsertPurchaseOrderHeaderInterface(DatabasePurchaseOrderReceiptHeader databaseIntegrationsInventoryAdjustment)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseIntegrationsInventoryAdjustment);
            }
        }

        public void InsertPurchaseOrderDetailInterface(DatabasePurchaseOrderReceiptDetail databaseIntegrationsInventoryAdjustment)
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

        public int InsertDatabasePoReceiptHeader(DatabasePurchaseOrderReceiptHeader databasePurchaseReceiptHeader)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return (int) connection.Insert(databasePurchaseReceiptHeader);
            }
        }

        public int InsertDatabasePurchaseOrderReceiptDetail(DatabasePurchaseOrderReceiptDetail databasePurchaseOrderDetailInterface)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return (int)connection.Insert(databasePurchaseOrderDetailInterface);
            }
        }

        public void InsertDatabasePurchaseOrderReceiptDetailLineItem(DatabasePurchaseOrderReceiptDetailLineItem databasePurchaseOrderReceiptDetailLineItem)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                connection.Insert(databasePurchaseOrderReceiptDetailLineItem);
            }
        }
    }
}
