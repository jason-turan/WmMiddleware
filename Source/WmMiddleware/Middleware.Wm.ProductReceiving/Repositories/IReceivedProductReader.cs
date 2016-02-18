using System.Collections.Generic;
using Middleware.Wm.ProductReceivingng.Models;

namespace Middleware.Wm.ProductReceivingng.Repositories
{
    public interface IReceivedProductReader
    {
        IEnumerable<IReceivedProduct> GetPurchaseOrders();
        IEnumerable<IReceivedProduct> GetAutomatedShippingNotifications();
        IEnumerable<IReceivedProduct> GetPurchaseReturns();

        void SetAsProcessed(IEnumerable<IReceivedProduct> products);
    }
}
