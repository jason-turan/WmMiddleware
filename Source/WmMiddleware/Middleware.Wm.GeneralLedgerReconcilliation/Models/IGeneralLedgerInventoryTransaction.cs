using System;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public interface IGeneralLedgerInventoryTransaction
    {
        string GeneralLedgerAccount { get; }
        string VarianceAccount { get; }
        string Sku { get; }
        int Quantity { get; }
        string UnitOfMeasure { get; }
        string BatchSource { get; }
        string BatchIdentification { get; }
        string ReasonCode { get; }
        DateTime InventoryDate { get; }
        DateTime BatchDate { get; }
        string IntegrationStatus { get; }
    }
}