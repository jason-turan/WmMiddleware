using System.IO;

namespace Middleware.Wm.TransferControl.Ftp
{
    public interface IManhattanFtp
    {
        void AppendInboundMasterControl(FileInfo fileInfo);

        void UploadInboundFile(FileInfo fileInfo);
    }
}
