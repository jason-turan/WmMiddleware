using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.GeneralLedgerReconcilliation.Models;

namespace WmMiddleware.GeneralLedgerReconcilliation.Repository
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
    }
}
