using System.Data.SqlClient;
using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public class XmlDatabaseCommand : IXmlReadRepository
    {
        private readonly string _connection;
        private readonly string _commandText;

        public XmlDatabaseCommand(string connection, string commandText)
        {
            _connection = connection;
            _commandText = commandText;
        }

        public XDocument Read()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandText = _commandText;
                var xmlReader = command.ExecuteXmlReader();
                return new XDocument(xmlReader);
            }
        }
    }
}
