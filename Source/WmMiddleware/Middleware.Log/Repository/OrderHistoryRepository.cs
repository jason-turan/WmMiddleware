using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Middleware.Log.Repository
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        public void Save(IEnumerable<OrderHistory> entries)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WarehouseManagementConnection"].ConnectionString))
            {
                connection.Insert(entries);
            }
        }
    }
}
