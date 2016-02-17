using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WmMiddleware.ProductReceiving.Models
{
    public class PurchaseOrder : IReceivedProduct
    {
        public PurchaseOrder()
        {
            Items = new Collection<LineItem>();
        }

        public ICollection<LineItem> Items { get; set; }

        public string ActionCode { get; set; } 
        public string InterfaceStatus { get; set; } 
        public DateTime InterfaceDate { get; set; } 
        public string ExternalUid { get; set; } 
        public DateTime PurchaseOrderDate { get; set; } 
        public string FacilityNumber { get; set; } 
        public string VendorAccount { get; set; } 
        public decimal AmountCost { get; set; } 
        public decimal DiscAvailability { get; set; } 
        public decimal AmountFreight { get; set; } 
        public DateTime DateDue { get; set; } 
        public string CreateReceiver { get; set; } 
        public string BuyerReferenceNumber { get; set; } 

        public override string ToString()
        {
            return string.Format("ExternalUID: {0}, Items: <{1}>", ExternalUid, string.Join(", ", Items));
        }
    }
}
