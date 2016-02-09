using System;
using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public class OmsOrderReader : IOrderReader
    {
        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void SetAsProcessed(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
