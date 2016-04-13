using System.IO;

namespace Middleware.Wm.TransferControl.Ftp
{
    public interface IFtpClient
    {
        bool Upload(FileInfo localFile, string remoteFileName);

        bool Download(string serverName, string localName);
        
        void Append(FileInfo localFile, string remoteFileName);
    }
}