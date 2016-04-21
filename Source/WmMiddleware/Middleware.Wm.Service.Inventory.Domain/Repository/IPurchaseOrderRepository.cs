using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder GetPurchaseOrder(string purchaseOrderId);
        void AddPurchaseOrder(PurchaseOrder newPurchaseOrder);
    }
}