using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace WmMiddleware.Picking.Repositories
{
    public interface IPickWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
