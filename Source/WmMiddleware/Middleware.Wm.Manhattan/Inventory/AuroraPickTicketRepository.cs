//using System.Collections.Generic;
//using Dapper.Contrib.Extensions;
//using Middleware.Wm.Configuration.Database;
//using Middleware.Wm.Manhattan.Inventory;

//namespace Middleware.Wm.Aurora.PickTickets.Repositories
//{
//    public class AuroraPickTicketRepository : IAuroraPickTicketRepository
//    {
//        public void InsertAuroraPickTicketHeader(IList<ManhattanPickTicketHeader> headers)
//        {
//            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
//            {
//                connection.Insert(headers);
//            }
//        }

//        public void InsertAuroraPickTicketDetail(IList<ManhattanPickTicketDetail> details)
//        {
//            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
//            {
//                connection.Insert(details);
//            }
//        }

//        public void InsertAuroraPickTicketInstruction(IList<ManhattanPickTicketInstruction> instructions)
//        {
//            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
//            {
//                connection.Insert(instructions);
//            }
//        }
//    }
//}
