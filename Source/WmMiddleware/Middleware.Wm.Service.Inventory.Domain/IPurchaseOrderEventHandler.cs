using Middleware.Wm.Service.Contracts.Models;
using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;


namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IPurchaseOrderEventHandler
    {
        void PurchaseOrderReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent);
        void PurchaseOrderStocked(PurchaseOrderStockedEvent stockedQuantities);
    }
    
}
