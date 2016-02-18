using Middleware.Wm.GeneralLedgerReconcilliation.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public interface IDatabaseRepository
    {
        void InsertIntegrationInventoryAdjustment(DatabaseIntegrationsInventoryAdjustment databaseIntegrationsInventoryAdjustment);
    }
}