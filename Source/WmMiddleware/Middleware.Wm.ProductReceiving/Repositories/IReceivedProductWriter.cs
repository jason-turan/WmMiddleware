using System.Collections.Generic;
using Middleware.Wm.ProductReceiving.Models;

namespace Middleware.Wm.ProductReceiving.Repositories
{
    public interface IReceivedProductWriter
    {
        void Save(IEnumerable<IReceivedProduct> receivedProducts);
    }
}
