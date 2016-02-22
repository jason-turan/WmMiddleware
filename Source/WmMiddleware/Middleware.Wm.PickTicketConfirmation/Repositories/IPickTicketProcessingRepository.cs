using System.Collections.Generic;
using Middleware.Wm.PickTicketConfirmation.Models;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public interface IPickTicketProcessingRepository
    {
        void InsertPickTicketProcessing(IList<PickTicketConfirmationOrderProcessing> processing);
    }
}
