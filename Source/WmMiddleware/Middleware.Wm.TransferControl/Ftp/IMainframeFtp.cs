using System.IO;

namespace Middleware.Wm.TransferControl.Ftp
{
    public interface IMainframeFtp
    {
        void AppendInboundMasterControl(FileInfo fileInfo, string masterControlPath, string masterControlFileName);
        void UploadInboundFile(FileInfo fileInfo, string destinationFtpPath);
    }
}
