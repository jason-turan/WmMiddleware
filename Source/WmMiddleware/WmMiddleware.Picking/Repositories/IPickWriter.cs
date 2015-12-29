using System.Collections.Generic;
using WmMiddleware.Picking.Models;

namespace WmMiddleware.Picking.Repositories
{
    public interface IPickWriter
    {
        void SaveOrders(IEnumerable<Order> orders);
    }
}
