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
    }
}
