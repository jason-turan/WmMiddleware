using System.Collections.Generic;
using Middleware.WarehouseManagement.Aurora.PickTickets.Models;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public interface IPickReader
    {
        IEnumerable<Order> GetOrders();
        void SetAsProcessed(IEnumerable<Order> orders);
    }
}
 