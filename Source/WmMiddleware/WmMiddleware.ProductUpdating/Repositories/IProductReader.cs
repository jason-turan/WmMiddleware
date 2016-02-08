using System;
using System.Collections.Generic;
using WmMiddleware.ProductUpdating.Models;

namespace WmMiddleware.ProductUpdating.Repositories
{
    public interface IProductReader
    {
        IEnumerable<Product> GetProducts(DateTime? startDateTime);
    }
}
