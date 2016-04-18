using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Domain
{
    interface IPurchaseOrderEventHandler
    {
        void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent);
        void InventoryStocked(List<ProductQuantity> stockedQuantities);
    }
    
}
