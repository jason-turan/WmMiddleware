using System.Collections.Generic;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.PixReturn.Models;

namespace WmMiddleware.PixReturn.Repository
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
