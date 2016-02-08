using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Manhattan.Inventory
{
    public interface IManhattanOrderRepository
    {
        ICollection<Order> GetOrders(string headerFileLocation, string detailsFileLocation, string instructionsFileLocation);
        void SaveOrders(IEnumerable<Order> orders, string headerFileLocation, string detailsFileLocation, string instructionsFileLocation);
    }
}
