using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Middleware.Wm.Inventory;
using Middleware.Wm.PickTicketConfirmation.Models;
using WmMiddleware.Configuration.Database;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public class OmsOrderReader : IOrderReader
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var connection = DatabaseConnectionFactory.GetGpConnection())
            {
                connection.Open();
                return GroupOrders(connection.Query<OmsOrderResult>("usp_GetBNCOrders")).ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Order> GroupOrders(IEnumerable<OmsOrderResult> orderResults)
        {
            var groupedTickets = orderResults.GroupBy(t => t.order_number);
            foreach (var group in groupedTickets)
            {
                var order = group.First().ToOrder();
                foreach (var item in group.Select(i => i.ToLineItem()))
                {
                    order.Items.Add(item);
                }
                yield return order;
            }
        }
    }
}
