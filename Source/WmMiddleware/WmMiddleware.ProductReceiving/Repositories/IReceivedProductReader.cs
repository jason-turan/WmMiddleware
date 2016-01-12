using System.Collections.Generic;
using WmMiddleware.ProductReceiving.Models;

namespace WmMiddleware.ProductReceiving.Repositories
{
    public interface IReceivedProductReader
    {
        IEnumerable<IReceivedProduct> GetPurchaseOrders();
        IEnumerable<IReceivedProduct> GetAutomatedShippingNotifications();
        IEnumerable<IReceivedProduct> GetPurchaseReturns();

        void SetAsProcessed(IEnumerable<IReceivedProduct> products);
    }
}
