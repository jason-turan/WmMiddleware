using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization; 

namespace NB.DTC.Aptos.InventoryService.Models
{
    /// <summary>
    /// Follow up with Steve to identify the put-away logic
    /// </summary>
    public class PurchaseOrderReceiptEvent 
    {
        public string PurchaseOrderUniqueIdentifier { get; set; }        
        public DateTime PurchaseOrderDate { get; set; }
        public string Sku { get; set; }
        public string Upc { get; set; }
        public string Class { get; set; }
        public int Quantity { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public List<ProductQuantity> ReceiptList { get; set; }

        public PurchaseOrderReceiptEvent(string ponumber,  
                                         List<ProductQuantity> productReceipts)
        {
            this.PurchaseOrderUniqueIdentifier = ponumber; 
            this.ReceiptList = productReceipts;            
        }
    }
}
