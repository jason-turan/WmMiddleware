using System.Collections.Generic;
using Middleware.Wm.ProductReceiving.Models;

namespace Middleware.Wm.ProductReceiving.Repositories
{
    public interface IReceivedProductReader
    {
        IEnumerable<IReceivedProduct> GetPurchaseOrders();
        IEnumerable<IReceivedProduct> GetAutomatedShippingNotifications();
        IEnumerable<IReceivedProduct> GetPurchaseReturns();

        void SetAsProcessed(IEnumerable<IReceivedProduct> products);
    }
}
