using System;
using System.Collections.Generic;
using Middleware.Wm.ProductUpdating.Models;

namespace Middleware.Wm.ProductUpdating.Repositories
{
    public interface IProductReader
    {
        IEnumerable<Product> GetProducts(DateTime? startDateTime);
    }
}
