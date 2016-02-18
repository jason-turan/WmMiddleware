using System.Collections.Generic;

namespace Middleware.Wm.TransferControl.Control
{
    public interface ITransferControlManager
    {
        void SaveTransferControl(string controlNumber, IList<string> files, int jobId);
    }
}
