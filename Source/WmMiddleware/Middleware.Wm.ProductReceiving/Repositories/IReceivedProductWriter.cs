using System.Collections.Generic;
using Middleware.Wm.ProductReceivingng.Models;

namespace Middleware.Wm.ProductReceivingng.Repositories
{
    public interface IReceivedProductWriter
    {
        void Save(IEnumerable<IReceivedProduct> receivedProducts);
    }
}
