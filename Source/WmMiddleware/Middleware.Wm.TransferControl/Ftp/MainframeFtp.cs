using System.IO;
using Middleware.Log;
using Middleware.Wm.Configuration;

namespace Middleware.Wm.TransferControl.Ftp
{
    public class MainframeFtp : IMainframeFtp
    {
        private readonly IFtpClient _ftpClient;
        private readonly ILog _log;

        public MainframeFtp(IConfigurationManager configuration, ILog log, IFtpClientFactory ftpClientFactory) 
        {
            _log = log;
            _ftpClient = ftpClientFactory.CreateFtpClient();
        }

        public void AppendInboundMasterControl(FileInfo masterControlFile, string masterControlPath, string masterControlFileName)
        {
            var remotePath = masterControlPath + "/" + masterControlFileName;
            _log.Debug("file upload " + masterControlFile.FullName + " to remote path " + remotePath);
            _ftpClient.Append(masterControlFile, remotePath);
            _log.Info("Successfully appended to master control file.");
        }
        
        public void UploadInboundFile(FileInfo fileInfo, string destinationFtpPath)
        {
            var remotePath = destinationFtpPath + "/" + fileInfo.Name;
            _log.Debug("file upload " + fileInfo.FullName + " to remote path " + remotePath);
            _ftpClient.Upload(fileInfo, destinationFtpPath + "/" + fileInfo.Name);
            _log.Info("Successfully uploaded " + fileInfo.FullName + " to " + destinationFtpPath);
        }
    }
}
