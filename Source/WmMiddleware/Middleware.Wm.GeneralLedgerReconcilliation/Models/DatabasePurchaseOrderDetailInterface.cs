using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("PODetail_Interface")]
    public class DatabasePurchaseOrderDetailInterface
    {
        private string UpdatePID { get; set; }
        private string ActionCode { get; set; }
        private string Direction { get; set; }
        private DateTime InterfaceDate { get; set; }
        private string InterfaceStatus { get; set; }
        private DateTime CreateDate { get; set; }
        private int IDPOHeaderInterface { get; set; }
        private string FacilityNbr { get; set; }
        private int POLineNbr { get; set; }
        private string SKU { get; set; }
        private string UPC { get; set; }
        private string Class { get; set; }
        private decimal QtyOrdered { get; set; }
        private string VendorPartNbr { get; set; }
        private string HotFlag { get; set; }
        private decimal Price { get; set; }
        private decimal Extension { get; set; }
        private DateTime DateExpect { get; set; }
        private string BuyerRef { get; set; }
        private string UOM { get; set; }
    }
    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
