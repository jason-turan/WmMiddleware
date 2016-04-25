using Middleware.Wm.Service.Inventory.Domain.Models;
using System;
using System.Collections.Generic; 

namespace Middleware.Wm.Service.Inventory.Models
{
    public class PurchaseOrder
    {
        public String PurchaseOrderId { get; set; }
        public DateTime? PurchaseOrderDateTime { get; set; }
        public String StoreId { get; set; }        
        public List<ProductStockedQuantity> ProductsStocked { get; set; }
    }
}