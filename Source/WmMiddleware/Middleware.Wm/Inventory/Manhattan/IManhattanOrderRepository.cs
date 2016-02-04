using System.Collections.Generic;

namespace Middleware.Wm.Inventory.Manhattan
{
    public interface IManhattanOrderRepository
    {
        ICollection<Order> GetOrders(string headerFileLocation, string detailsFileLocation, string instructionsFileLocation);
    }
}
