using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization; 

namespace Middleware.Wm.Service.Inventory.Models
{
    public class PurchaseOrderReceiptEvent 
    {
        public string PurchaseOrderUniqueIdentifier { get; set; }        
        public DateTime ReceiptDateTime { get; set; }
        public List<ProductQuantity> ReceiptList { get; set; }

        public PurchaseOrderReceiptEvent(string ponumber, 
                                         DateTime receiptDateTime, 
                                         List<ProductQuantity> productReceipts)
        {
            PurchaseOrderUniqueIdentifier = ponumber; 
            ReceiptList = productReceipts;
            ReceiptDateTime = receiptDateTime;
        }
    }
}
