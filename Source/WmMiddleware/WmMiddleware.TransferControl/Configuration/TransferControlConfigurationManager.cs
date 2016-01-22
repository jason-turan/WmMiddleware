using WmMiddleware.Configuration;

namespace WmMiddleware.TransferControl.Configuration
{
    public class TransferControlConfigurationManager : ITransferControlConfigurationManager
    {
        private readonly IConfigurationManager _configurationManager;

        public TransferControlConfigurationManager(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string GetOutboundFileDirectory()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileDirectory);
        }

        public string GetOutboundFileProcessedDirectory()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileProcessedDirectory);
        }

        public string GetInboundFileDirectory()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory);
        }

        public string GetInboundFileProcessedDirectory()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);
        }

        public string GetInboundMasterControlFilename()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
        }

        public string GetOutboundMasterControlFilename()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundMasterControlFileName);
        }

        public string GetInboundFtpLocation()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFtpLocation);
        }

        public string GetInboundFtpUsername()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlFtpUserName);
        }

        public bool IsFtpEnabled()
        {
            return _configurationManager.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable);
        }
    }
}
