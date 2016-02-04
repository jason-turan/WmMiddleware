using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Aurora.PickTicketConfirmation.Repositories
{
    public interface IPickWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
