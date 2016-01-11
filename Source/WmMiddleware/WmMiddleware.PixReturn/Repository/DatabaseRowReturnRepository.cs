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
    }
}
