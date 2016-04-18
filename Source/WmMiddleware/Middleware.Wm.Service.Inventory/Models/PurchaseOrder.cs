using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Middleware.Wm.Service.Inventory.Models
{
    public class PurchaseOrder
    {
        String PurchaseOrderId { get; set; }
        DateTime PurchaseOrderDateTime { get; set; }
        String Style { get; set; }
        String Width { get; set; }
        String Size { get; set; }
        String SeasonYear { get; set; }
        String StoreId { get; set; }
        int Quantity { get; set; }
        int UnstockedQuantity { get; set; }
        PurchaseOrderStatus Status { get; set; }
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