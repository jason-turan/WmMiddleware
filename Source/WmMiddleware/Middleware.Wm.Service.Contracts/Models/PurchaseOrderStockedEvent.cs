using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Contracts.Models
{
    public class PurchaseOrderStockedEvent
    {
        [Required]
        public string PurchaseOrderNumber { get; set; }

        [Required]
        public DateTime ReceiptDateTime { get; set; }

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
