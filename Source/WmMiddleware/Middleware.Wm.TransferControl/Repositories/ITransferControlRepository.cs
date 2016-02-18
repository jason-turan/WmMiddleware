using System.Collections.Generic;
using Middleware.Wm.TransferControl.Models;

namespace Middleware.Wm.TransferControl.Repositories
{
    public interface ITransferControlRepository
    {
        Models.TransferControl GetTransferControl(int transferControlId);

        IEnumerable<Models.TransferControl> FindTransferControls(TransferControlSearchCriteria transferControlSearchCriteria);

        int InsertTransferControl(Models.TransferControl transferControl);

        void UpdateTransferControl(Models.TransferControl transferControl);
    }
}
