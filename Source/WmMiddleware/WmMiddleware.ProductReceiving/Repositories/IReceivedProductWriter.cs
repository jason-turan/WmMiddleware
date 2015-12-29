using System.Collections.Generic;
using WmMiddleware.ProductReceiving.Models;

namespace WmMiddleware.ProductReceiving.Repositories
{
    public interface IReceivedProductWriter
    {
        void Save(IEnumerable<IReceivedProduct> receivedProducts);
    }
}
