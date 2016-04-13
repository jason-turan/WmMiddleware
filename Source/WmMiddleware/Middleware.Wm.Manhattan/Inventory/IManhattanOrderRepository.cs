using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Manhattan.Inventory
{
    public interface IManhattanOrderRepository
    {
        ICollection<Order> GetOrders(IList<ManhattanPickTicketHeader> headers, IList<ManhattanPickTicketDetail> details);
        void SaveOrders(IEnumerable<Order> orders, string headerFileLocation, string detailsFileLocation, string instructionsFileLocation);
        IList<ManhattanPickTicketHeader> GetManhattanPickTicketHeaders(string headerFileLocation);
        IList<ManhattanPickTicketDetail> GetManhattanPickTicketDetails(string detailsFileLocation);
        IList<ManhattanPickTicketInstruction> GetManhattanPickTicketInstructions(string instructionsFileLocation);
    }
}
