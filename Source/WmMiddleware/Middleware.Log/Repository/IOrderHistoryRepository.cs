using System.Collections.Generic;

namespace Middleware.Log.Repository
{
    public interface IOrderHistoryRepository
    {
        void Save(IEnumerable<OrderHistory> entries);
    }
}
