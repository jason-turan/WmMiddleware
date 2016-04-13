
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("POReceiptHeader")]
    public class DatabasePurchaseOrderReceiptHeader
    {
        public string SenderID { get; set; }
        public string RecipientID { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string ControlNumber { get; set; }
        public string UsageIndicator { get; set; }
        public string ISAControlNumber { get; set; }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
