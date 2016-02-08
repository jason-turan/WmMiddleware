using System.Collections.Generic;

namespace Middleware.Wm.Inventory
{
    public interface IOrderWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
