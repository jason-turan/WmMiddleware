using System.Collections.Generic;

namespace Middleware.Wm.Inventory
{
    public interface IOrderReader
    {
        IEnumerable<Order> GetOrders();
        void SetAsProcessed(IEnumerable<Order> orders);
    }
}
 