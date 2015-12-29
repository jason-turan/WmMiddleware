using System.Collections.Generic;
using WmMiddleware.ProductUpdating.Models;

namespace WmMiddleware.ProductUpdating.Repositories
{
    public interface IProductWriter
    {
        void SaveProducts(IEnumerable<Product> products);
    }
}
