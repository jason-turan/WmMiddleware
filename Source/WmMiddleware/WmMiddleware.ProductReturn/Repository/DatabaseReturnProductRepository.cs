using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.ProductReturn.Models;

namespace WmMiddleware.ProductReturn.Repository
{
    public class DatabaseReturnProductRepository : IReceivedPurchaseReturnReader
    {
        public IList<DatabaseProductReturn> GetProductReturns()
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return connection.Query<DatabaseProductReturn>("sp_GetNewReturns").ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<DatabaseProductReturn> returns)
        {
            throw new NotImplementedException();
        }
    }
}
