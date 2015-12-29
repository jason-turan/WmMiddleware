using System.IO;
using System.Text;
using WmMiddleware.Configuration;
using MiddleWare.Log;
using WmMiddleware.TransferControl.Models;

namespace WmMiddleware.TransferControl.Ftp
{
    public class ManhattanFtp : IManhattanFtp
    {
        private readonly IConfigurationManager _configuration;
        private readonly IFtpClient _ftpClient;
        private readonly Encoding _encoding;
        private readonly ILog _log;

        public ManhattanFtp(IConfigurationManager configuration, ILog log, IFtpClient ftpClient) 
        {
            _configuration = configuration;

            _log = log;

            _ftpClient = ftpClient;

            _encoding = Encoding.GetEncoding("IBM037");
        }

        public void AppendInboundMasterControl(FileInfo masterControlFile)
        {
            EncodeFile(masterControlFile);

            _ftpClient.Append(masterControlFile, GetMasterControlFtpPath(), GetFtpOptions());
            _log.Info("Successfully appended to master control file.");
        }
        
        public void UploadInboundFile(FileInfo fileInfo)
        {
            var destinationFtpPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFtpLocation);
            
            EncodeFile(fileInfo);

            _ftpClient.Upload(fileInfo, destinationFtpPath + "/" + fileInfo.Name, GetFtpOptions());

            _log.Info("Successfully uploaded " + fileInfo.FullName + " to " + destinationFtpPath);
        }

        private string GetMasterControlFtpPath()
        {
            var masterControlPath = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
            var masterControlFileName = _configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);

            return masterControlPath + "/" + masterControlFileName;
        }

        private void EncodeFile(FileSystemInfo masterControlFile)
        {
            string text = File.ReadAllText(masterControlFile.FullName, _encoding);

            File.WriteAllText(masterControlFile.FullName, text, _encoding);
        }

        private FtpOptions GetFtpOptions()
        {
            return new FtpOptions
            {
                Host = _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpManhattanServer),
                UserId = _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpUserName),
                Password = _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpPassword),
                UseBinary = false
            };
        }
    }
}
