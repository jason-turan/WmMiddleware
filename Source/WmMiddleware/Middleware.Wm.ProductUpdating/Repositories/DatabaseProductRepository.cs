using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.ProductUpdating.Models;

namespace Middleware.Wm.ProductUpdating.Repositories
{
    public class DatabaseProductRepository : IProductReader
    {
        private readonly TimeSpan _getProductsCommandTimeout = TimeSpan.FromMinutes(2);

        public IEnumerable<Product> GetProducts(DateTime? startDateTime)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LastSuccess", startDateTime, DbType.DateTime);
                connection.Open();
                return connection.Query<DatabaseProduct>("sp_GetAccessoryItemMaster", 
                                                         parameters, 
                                                         commandTimeout: (int)_getProductsCommandTimeout.TotalSeconds,
                                                         commandType: CommandType.StoredProcedure).
                                  Select(dp => dp.ToProduct()).
                                  ToList();
            }
        }
    }
}
