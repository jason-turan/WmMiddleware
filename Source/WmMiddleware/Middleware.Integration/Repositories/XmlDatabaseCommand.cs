using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
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
            var connectionConfiguration = ConfigurationManager.ConnectionStrings[_connection];
            var connectionString = connectionConfiguration == null ? _connection : connectionConfiguration.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = _commandText;
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var writer = new StringWriter();
                        var table = new DataTable("Table");
                        var dataset = new DataSet("NewDataSet");
                        dataset.Tables.Add(table);
                        adapter.Fill(table);
                        table.WriteXml(writer);
                        return XDocument.Parse(writer.ToString());
                    }
                }
            }
        }

    }
}
