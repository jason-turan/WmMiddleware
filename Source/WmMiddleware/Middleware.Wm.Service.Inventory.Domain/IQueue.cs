using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Domain
{
    internal interface IQueue
    {
        void QueueWorkItem(string receivedOnLocation_NotifyRiba, PurchaseOrder po);
    }
}