using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace WmMiddleware.Picking.Repositories
{
    public interface IPickReader
    {
        IEnumerable<Order> GetOrders();
        void SetAsProcessed(IEnumerable<Order> orders);
    }
}
 