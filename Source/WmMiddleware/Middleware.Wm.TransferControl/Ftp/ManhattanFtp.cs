using System.IO;
using MiddleWare.Log;
using Middleware.Wm.Configuration;

namespace Middleware.Wm.TransferControl.Ftp
{
    public class ManhattanFtp : IManhattanFtp
    {
        private readonly IConfigurationManager _configuration;
        private readonly IFtpClient _ftpClient;
        private readonly ILog _log;

        public ManhattanFtp(IConfigurationManager configuration, ILog log, IFtpClientFactory ftpClientFactory) 
        {
            _configuration = configuration;
            _log = log;
            _ftpClient = ftpClientFactory.CreateFtpClient();
        }

        public void AppendInboundMasterControl(FileInfo masterControlFile)
        {
            _ftpClient.Append(masterControlFile, GetMasterControlFtpPath());
            _log.Info("Successfully appended to master control file.");
        }
        
        public void UploadInboundFile(FileInfo fileInfo)
        {
            var destinationFtpPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFtpLocation);
            
            _ftpClient.Upload(fileInfo, destinationFtpPath + "/" + fileInfo.Name);

            _log.Info("Successfully uploaded " + fileInfo.FullName + " to " + destinationFtpPath);
        }

        private string GetMasterControlFtpPath()
        {
            var masterControlPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
            var masterControlFileName = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);

            return masterControlPath + "/" + masterControlFileName;
        }

    }
}
