using System.IO;

namespace WmMiddleware.TransferControl.Control
{
    public interface IFileIo
    {
        void Move(FileInfo fromLocation, FileInfo toLocation);
    }
}
