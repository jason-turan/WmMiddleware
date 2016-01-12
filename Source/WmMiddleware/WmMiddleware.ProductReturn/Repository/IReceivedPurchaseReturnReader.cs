using System.Collections.Generic;
using WmMiddleware.ProductReturn.Models;

namespace WmMiddleware.ProductReturn.Repository
{
    public interface IReceivedPurchaseReturnReader
    {
        IList<Models.DatabaseProductReturn> GetProductReturns();
        void SetAsProcessed(IEnumerable<DatabaseProductReturn> returns);
    }
}
