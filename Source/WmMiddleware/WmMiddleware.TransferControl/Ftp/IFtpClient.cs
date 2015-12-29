using System.IO;
using WmMiddleware.TransferControl.Models;

namespace WmMiddleware.TransferControl.Ftp
{
    public interface IFtpClient
    {
        bool Upload(FileInfo localFile, string remoteFileName, FtpOptions ftpOptions);

        bool Download(string serverName, string localName, FtpOptions ftpOptions);
        
        void Append(FileInfo localFile, string remoteFileName, FtpOptions ftpOptions);
    }
}