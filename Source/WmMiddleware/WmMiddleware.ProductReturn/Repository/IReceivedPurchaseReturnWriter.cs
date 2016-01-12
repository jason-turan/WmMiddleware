using System.Collections.Generic;
using WmMiddleware.ProductReturn.Models;

namespace WmMiddleware.ProductReturn.Repository
{
    public interface IReceivedPurchaseReturnWriter
    {
        void Save(IEnumerable<PurchaseReturn> receivedProducts);
    }
}
