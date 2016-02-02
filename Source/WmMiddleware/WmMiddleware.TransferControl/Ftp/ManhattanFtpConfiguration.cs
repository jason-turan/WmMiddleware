using WmMiddleware.Configuration;

namespace WmMiddleware.TransferControl.Ftp
{
    public class ManhattanFtpConfiguration : IFtpClientConfiguration
    {
        private readonly IConfigurationManager _configuration;

        public ManhattanFtpConfiguration(IConfigurationManager configuration)
        {
            _configuration = configuration;
        }

        public string GetHost()
        {
            return _configuration.GetKey<string>(ConfigurationKey.TransferControlFtpManhattanServer);
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
