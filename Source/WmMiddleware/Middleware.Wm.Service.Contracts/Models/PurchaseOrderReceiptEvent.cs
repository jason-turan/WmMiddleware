using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    public class PurchaseOrderReceiptEvent 
    {
        [Required]
        public string PurchaseOrderNumber { get; set; }

        [Required]
        public DateTime ReceiptDateTime { get; set; }
               
        public PurchaseOrderReceiptEvent(string ponumber, 
                                         DateTime receiptDateTime)
        {
            PurchaseOrderNumber = ponumber;  
            ReceiptDateTime = receiptDateTime;
        }
    }
}
