using System.Collections.Generic;
using WmMiddleware.Picking.Models;

namespace WmMiddleware.Picking.Repositories
{
    public interface IPickReader
    {
        IEnumerable<Order> GetOrders();
        void SetAsProcessed(IEnumerable<Order> orders);
    }
}
 