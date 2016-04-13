using System.Collections.Generic;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.PixReturn.Models;

namespace Middleware.Wm.PixReturn.Repository
{
    public class ManhattanConditionCodeRepository : IManhattanConditionCodeRepository
    {
        public IEnumerable<ManhattanConditionCode> GetConditionCodes()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanConditionCode>("SELECT * FROM ManhattanConditionCode");
            }  
        }
    }
}
