using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Aurora.PickTicketConfirmation.Repositories
{
    public interface IPickReader
    {
        IEnumerable<Order> GetOrders();
        void SetAsProcessed(IEnumerable<Order> orders);
    }
}
 