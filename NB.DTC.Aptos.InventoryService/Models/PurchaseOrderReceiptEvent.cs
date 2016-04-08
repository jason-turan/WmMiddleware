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
        public string PONumber { get; set; }        
        public List<ProductQuantity> ReceiptList { get; set; }

        public PurchaseOrderReceiptEvent(string ponumber,  
                                         List<ProductQuantity> productReceipts)
        {
            this.PONumber = ponumber; 
            this.ReceiptList = productReceipts;            
        }
    }
}
