
using Middleware.Wm.Configuration;
using Middleware.Wm.TransferControl.Ftp;

namespace Middleware.Wm.Aurora.PickTickets.Ftp
{
    public class OmsFtpClientConfiguration : IFtpClientConfiguration
    {
        private readonly IConfigurationManager _configurationManager;

        public OmsFtpClientConfiguration(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        
        public string GetHost()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.OmsAuroraSftpHost);
        }

        public string GetPassword()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.OmsAuroraSftpPassword);
        }

        public string GetUsername()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.OmsAuroraSftpUsername);
        }
    }
}
