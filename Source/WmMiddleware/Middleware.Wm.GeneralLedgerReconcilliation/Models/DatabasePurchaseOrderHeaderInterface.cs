using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("POHeader_Interface")]
    public class DatabasePurchaseOrderHeaderInterface
    {
        public string ActionCode { get; set; }
        public string Direction { get; set; }
        public string UpdatePID { get; set; }
        public string InterfaceStatus { get; set; }
        public DateTime InterfaceDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string ExternalUID { get; set; }
        public int POSTATUS { get; set; }
        public int POTYPE { get; set; }
        public DateTime PODate { get; set; }
        public string FacilityNbr { get; set; }
        public string VendorAcct { get; set; }
        public decimal AmtCost { get; set; }
        public decimal DiscAvail { get; set; }
        public decimal AmtFreight { get; set; }
        public DateTime DateDue { get; set; }
        public string CreateReceiver { get; set; }
        public string BuyerRefNbr { get; set; }
    }
    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
