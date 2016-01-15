using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.PixReturn.Models;

namespace WmMiddleware.PixReturn.Repository
{
    public class DatabaseRowReturnRepository : IDatabaseRowReturnRepository
    {
        public void InsertRowReturn(DatabaseRowReturn databaseRowReturn)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseRowReturn);
            }   
        }

        public string GetCompanyFromOrderNumber(string orderNumber)
        {
            string sql = @"SELECT company 
                           FROM nbxweb.dbo.gp_header (nolock) 
                           WHERE order_number = '" + orderNumber + "'";

            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                return connection.ExecuteScalar<string>(sql);
            }
        }
    }
}
