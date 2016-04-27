using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Contracts.Models
{
    /// <summary>
    /// Event to signify that a purchase order has been stocked. 
    /// </summary>
    public class PurchaseOrderStockedEvent
    {
        [Required]
        public string PurchaseOrderNumber { get; set; }

        [Required]
        public DateTime ReceiptDateTime { get; set; }

        /// <summary>
        /// Actual quantities received
        /// </summary>
        [Required]
        public List<ProductQuantity> ReceiptList { get; set; }

        public PurchaseOrderStockedEvent(string ponumber,
                                         DateTime receiptDateTime,
                                         List<ProductQuantity> productReceipts)
        {
            PurchaseOrderNumber = ponumber;
            ReceiptList = productReceipts;
            ReceiptDateTime = receiptDateTime;
        }

    }
}
