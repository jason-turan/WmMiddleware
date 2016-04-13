using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Aurora.PickTickets.Models;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.Aurora.PickTickets.Repositories
{
    public class AuroraPickTicketRepository : IAuroraPickTicketRepository
    {
        public void InsertAuroraPickTicketHeader(IList<ManhattanPickTicketHeader> headers)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(headers);
            }
        }

        public void InsertAuroraPickTicketDetail(IList<ManhattanPickTicketDetail> details)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(details);
            }
        }

        public void InsertAuroraPickTicketInstruction(IList<ManhattanPickTicketInstruction> instructions)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(instructions);
            }
        }

        public AuroraPickTicket GetAuroraPickTicket(string pickTicketControlNumber)
        {
            const string headerSql = "SELECT * FROM AuroraPickTicketHeader WHERE PickticketControlNumber = @PickTicketControlNumber";
            const string detailSql = "SELECT * FROM AuroraPickTicketDetail WHERE PickticketControlNumber = @PickTicketControlNumber";
            var parameter = new DynamicParameters();
            parameter.Add("@PickTicketControlNumber", pickTicketControlNumber.Split('-')[0]);

            var auroraPickTicket = new AuroraPickTicket();

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                auroraPickTicket.Header = connection.Query<ManhattanPickTicketHeader>(headerSql, parameter).SingleOrDefault();
                auroraPickTicket.Details = connection.Query<ManhattanPickTicketDetail>(detailSql, parameter).ToList();
            }

            return auroraPickTicket;
        }
    }
}
