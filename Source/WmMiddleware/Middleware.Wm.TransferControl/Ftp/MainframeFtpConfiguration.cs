using Middleware.Wm.Configuration;

namespace Middleware.Wm.TransferControl.Ftp
{
    public class MainframeFtpConfiguration : IFtpClientConfiguration
    {
        private readonly IConfigurationManager _configuration;

        public MainframeFtpConfiguration(IConfigurationManager configuration)
        {
            _configuration = configuration;
        }

        public string GetHost()
        {
            return _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpServer);
        }

        public string GetPassword()
        {
            return _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpPassword);
        }

        public string GetUsername()
        {
            return _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpUserName);
        }
    }
}
