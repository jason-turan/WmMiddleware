using System.IO;

namespace WmMiddleware.TransferControl.Ftp
{
    public interface IManhattanFtp
    {
        void AppendInboundMasterControl(FileInfo fileInfo);

        void UploadInboundFile(FileInfo fileInfo);
    }
}
