using System;
using System.Collections.Generic;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.Aurora.PickTicketConfirmation.Repositories
{
    public class ManhattanOrderWriter : IOrderWriter
    {
        private readonly IManhattanOrderRepository _manhattanOrderRepository;

        public ManhattanOrderWriter(IManhattanOrderRepository manhattanOrderRepository)
        {
            _manhattanOrderRepository = manhattanOrderRepository;
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
