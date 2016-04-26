using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;


namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IPurchaseOrderEventHandler
    {
        void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent);
        void InventoryStocked(List<ProductQuantity> stockedQuantities);
    }
    
}
