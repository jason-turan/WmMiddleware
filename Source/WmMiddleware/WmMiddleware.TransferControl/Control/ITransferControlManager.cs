using System.Collections.Generic;

namespace WmMiddleware.TransferControl.Control
{
    public interface ITransferControlManager
    {
        void SaveTransferControl(string controlNumber, IList<string> files, int jobId);
    }
}
