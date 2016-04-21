using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IPurchaseOrderEventHandler
    {
        void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent);
        void InventoryStocked(List<ProductQuantity> stockedQuantities);
    }
    
}
