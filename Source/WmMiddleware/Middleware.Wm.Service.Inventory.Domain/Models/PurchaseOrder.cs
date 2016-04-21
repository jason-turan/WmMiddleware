using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Middleware.Wm.Service.Inventory.Models
{
    public class PurchaseOrder
    {
        public String PurchaseOrderId { get; set; }
        public DateTime PurchaseOrderDateTime { get; set; }
        public String Upc { get; set; }
        public String StoreId { get; set; }
        public int Quantity { get; set; }
        public int UnstockedQuantity { get; set; }
        public PurchaseOrderStatus Status { get; set; }
    }
}

namespace Middleware.Wm.Service.Inventory.Models
{
    public enum PurchaseOrderStatus
    {
        InTransit,
        Received,
        Stocked
    }
}