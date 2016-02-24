using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("Integrations_Inventory_Adjustment")]
    public class DatabaseIntegrationsInventoryAdjustment
    {
        public DatabaseIntegrationsInventoryAdjustment(GeneralLedgerInventoryTransactionInterface glInterface)
        {
            created_date = glInterface.BatchDate;
            batch_create_dt = glInterface.BatchDate;
            batch_id = glInterface.BatchIdentification;
            batch_source = glInterface.BatchSource;
            gl_account = glInterface.GeneralLedgerAccount.Trim();
            item_key_id = glInterface.Sku;
            UOM = glInterface.UnitOfMeasure;
            qty = glInterface.Quantity;
            reason_code = glInterface.ReasonCode;
            variance_account = glInterface.VarianceAccount;
            inventory_variance_date = glInterface.InventoryDate;
            IntegrationStatus = glInterface.IntegrationStatus;
        }

        public string batch_id { get; set; }
        public string batch_source { get; set; }
        public DateTime batch_create_dt { get; set; }
        public DateTime created_date { get; set; }
        public string item_key_id { get; set; }
        public string UOM { get; set; }
        public int qty { get; set; }
        public DateTime? inventory_variance_date { get; set; }
        public string gl_account { get; set; }
        public string variance_account { get; set; }
        public string reason_code { get; set; }
        public string IntegrationStatus { get; set; }
        public DateTime? IntegrationMessage { get; set; }
        public DateTime? IntegrationDT { get; set; }
        public string IntegrationBatchID { get; set; }
    }
    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
