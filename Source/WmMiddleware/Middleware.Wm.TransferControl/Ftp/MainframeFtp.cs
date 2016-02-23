using System.IO;
using MiddleWare.Log;
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
            _ftpClient.Append(masterControlFile, masterControlPath + "/" + masterControlFileName);
            _log.Info("Successfully appended to master control file.");
        }
        
        public void UploadInboundFile(FileInfo fileInfo, string destinationFtpPath)
        {

            _ftpClient.Upload(fileInfo, destinationFtpPath + "/" + fileInfo.Name);

            _log.Info("Successfully uploaded " + fileInfo.FullName + " to " + destinationFtpPath);
        }

        private string GetMasterControlFtpPath(string masterControlPath, string masterControlFileName)
        {
            //var masterControlPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
            //var masterControlFileName = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);

            return masterControlPath + "/" + masterControlFileName;
        }

    }
}
