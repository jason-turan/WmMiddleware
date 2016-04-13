using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.PickTicketConfirmation.Models;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public class PickTicketOrderConfirmationProcessingRepository : IPickTicketProcessingRepository
    {
        public void InsertPickTicketProcessing(IList<PickTicketConfirmationOrderProcessing> processing)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(processing);
            }
        }
    }
}
