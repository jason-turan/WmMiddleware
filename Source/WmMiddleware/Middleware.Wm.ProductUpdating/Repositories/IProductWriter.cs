using System.Collections.Generic;
using Middleware.Wm.ProductUpdating.Models;

namespace Middleware.Wm.ProductUpdating.Repositories
{
    public interface IProductWriter
    {
        void SaveProducts(IEnumerable<Product> products);
    }
}
