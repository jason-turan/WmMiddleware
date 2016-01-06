using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.ProductUpdating.Models;

namespace WmMiddleware.ProductUpdating.Repositories
{
    public class DatabaseProductRepository : IProductReader
    {
        private readonly TimeSpan _getProductsCommandTimeout = TimeSpan.FromMinutes(2);

        public IEnumerable<Product> GetProducts(DateTime startDateTime)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                var parameters = new {LastSuccess = startDateTime};
                connection.Open();
                return connection.Query<DatabaseProduct>("sp_GetAccessoryItemMaster", parameters, commandTimeout: (int)_getProductsCommandTimeout.TotalSeconds).Select(dp => dp.ToProduct()).ToList();
            }
        }
    }
}
