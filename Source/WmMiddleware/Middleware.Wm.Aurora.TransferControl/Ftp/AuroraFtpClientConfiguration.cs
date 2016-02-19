using Middleware.WM.Aurora.TransferControl.Configuration;
using Middleware.Wm.Configuration;
using Middleware.Wm.TransferControl.Ftp;

namespace Middleware.Wm.Aurora.TransferControl.Ftp
{
    public class AuroraFtpClientConfiguration : IFtpClientConfiguration
    {
        private readonly IConfigurationManager _configurationManager;

        public AuroraFtpClientConfiguration(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string GetHost()
        {
            return _configurationManager.GetKey<string>(AuroraTransferControlConfigurationManager.AuroraPrefix + ConfigurationKey.TransferControlFtpManhattanServer);
        }

        public string GetPassword()
        {
            return _configurationManager.GetKey<string>(AuroraTransferControlConfigurationManager.AuroraPrefix + ConfigurationKey.TransferControlFtpPassword);
        }

        public string GetUsername()
        {
            return _configurationManager.GetKey<string>(AuroraTransferControlConfigurationManager.AuroraPrefix + ConfigurationKey.TransferControlFtpUserName);
        }
    }
}
