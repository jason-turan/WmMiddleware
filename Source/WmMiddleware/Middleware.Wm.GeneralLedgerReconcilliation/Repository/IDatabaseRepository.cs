using WmMiddleware.GeneralLedgerReconcilliation.Models;

namespace WmMiddleware.GeneralLedgerReconcilliation.Repository
{
    public interface IDatabaseRepository
    {
        void InsertIntegrationInventoryAdjustment(DatabaseIntegrationsInventoryAdjustment databaseIntegrationsInventoryAdjustment);
    }
}