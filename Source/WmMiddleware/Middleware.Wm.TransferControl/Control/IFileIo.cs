using System.IO;

namespace Middleware.Wm.TransferControl.Control
{
    public interface IFileIo
    {
        void Move(FileInfo fromLocation, FileInfo toLocation);
    }
}
