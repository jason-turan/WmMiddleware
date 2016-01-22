using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WmMiddleware.ProductReceiving.Models
{
    public class PurchaseReturn : IReceivedProduct
    {
        public PurchaseReturn()
        {
            Items = new Collection<PurchaseReturnLineItem>();
        }

        public ICollection<PurchaseReturnLineItem> Items { get; set; }

        public string OrderNumber { get; set; }
        
        public string ReturnReason { get; set; }
        
        public string ReturnReasonAdditionalInformation { get; set; }
        
        public string ToBeExchange { get; set; }
        
        public DateTime CustomerReturnDate { get; set; }
        
        public string TrackingNumber { get; set; }
        
        public int QuantityOrdered { get; set; }
    }
}
