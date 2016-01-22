using System.Collections.Generic;
using Middleware.WarehouseManagement.Aurora.PickTickets.Models;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public interface IPickWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
