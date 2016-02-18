using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("Integrations_Inventory_Adjustment")]
    public class DatabaseIntegrationsInventoryAdjustment
    {
        private string batch_id { get; set; }
        private string batch_source { get; set; }
        private DateTime batch_create_dt { get; set; }
        private DateTime created_date { get; set; }
        private string item_key_id { get; set; }
        private string UOM { get; set; }
        private int qty { get; set; }
        private DateTime inventory_variance_date { get; set; }
        private string gl_account { get; set; }
        private string variance_account { get; set; }
        private string reason_code { get; set; }
        private string IntegrationStatus { get; set; }
        private DateTime IntegrationMessage { get; set; }
        private DateTime IntegrationDT { get; set; }
        private string IntegrationBatchID { get; set; }
    }
    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
