using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public void AddPurchaseOrder(PurchaseOrder newPurchaseOrder)
        {            
        }

        public PurchaseOrder GetPurchaseOrder(string purchaseOrderId)
        {
            //Stubbed feel free to delete
            return new PurchaseOrder()
            {
                PurchaseOrderId = purchaseOrderId,
                PurchaseOrderDateTime = DateTime.Now,                
                StoreId = "500",
                ProductsStocked = new List<Domain.Models.ProductStockedQuantity>()
                {
                    new Domain.Models.ProductStockedQuantity() {
                        Quantity = 100,
                        UnstockedQuantity = 50,
                        Upc = "123"
                    }
                }
            };
        }
    }
}