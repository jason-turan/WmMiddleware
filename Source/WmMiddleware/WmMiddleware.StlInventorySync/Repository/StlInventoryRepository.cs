using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.StlInventorySync.Models;

namespace WmMiddleware.StlInventorySync.Repository
{
    public class StlInventoryRepository : IStlInventoryRepository
    {
        public IEnumerable<StlInventory> GetStlInventorySync()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                return connection.Query<StlInventory>("sp_GetStlInventorySync");
            }
        }

        public void InsertStlInventory(IList<StlInventory> stlInventory)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(stlInventory);
            }
        }

    }
}
