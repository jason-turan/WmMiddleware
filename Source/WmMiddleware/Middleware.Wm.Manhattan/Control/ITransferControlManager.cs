using System.Collections.Generic;

namespace Middleware.Wm.Manhattan.Control
{
    public interface ITransferControlManager
    {
        void SaveTransferControl(string controlNumber, IList<string> files, int jobId);
    }
}
