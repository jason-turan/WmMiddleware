using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public interface IPickWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
