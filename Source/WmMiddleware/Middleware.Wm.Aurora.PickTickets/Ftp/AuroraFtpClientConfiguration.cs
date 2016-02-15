using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Ftp;

namespace Middleware.Wm.Aurora.PickTickets.Ftp
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
