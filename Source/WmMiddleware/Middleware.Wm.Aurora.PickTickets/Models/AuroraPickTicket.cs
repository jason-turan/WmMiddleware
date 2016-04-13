using System.Collections.Generic;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.Aurora.PickTickets.Models
{
    public class AuroraPickTicket
    {
        public ManhattanPickTicketHeader Header { get; set; }
        public IList<ManhattanPickTicketDetail> Details { get; set; } 
        public IList<ManhattanPickTicketInstruction> SpeciInstructions { get; set; }
    }
}
