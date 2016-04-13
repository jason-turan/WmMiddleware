using Middleware.Jobs.Models;
using Middleware.Wm.Configuration;
using Middleware.Wm.TransferControl.Configuration;

namespace Middleware.WM.Aurora.TransferControl.Configuration
{
    public class AuroraTransferControlConfigurationManager : ITransferControlConfigurationManager
    {
        private readonly IConfigurationManager _configurationManager;
        public const string AuroraPrefix = "Aurora_";

        public AuroraTransferControlConfigurationManager(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public JobType GetInboundJobType()
        {
            return JobType.AuroraInbound;
        }

        public string GetOutboundFileDirectory()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlOutboundFileDirectory);
        }

        public string GetOutboundFileProcessedDirectory()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlOutboundFileProcessedDirectory);
        }

        public string GetInboundFileDirectory()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlInboundFileDirectory);
        }

        public string GetInboundFileProcessedDirectory()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlInboundFileProcessedDirectory);
        }

        public string GetInboundMasterControlFilename()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlInboundMasterControlFilename);
        }

        public string GetOutboundMasterControlFilename()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlOutboundMasterControlFileName);
        }

        public string GetInboundFtpLocation()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlInboundFtpLocation);
        }

        public string GetInboundFtpUsername()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlFtpUserName);
        }

        public bool IsFtpEnabled()
        {
            return _configurationManager.GetKey<bool>(AuroraPrefix + ConfigurationKey.TransferControlFtpEnable);
        }

        public string GetInboundMasterFileFtpLocation()
        {
            return _configurationManager.GetKey<string>(AuroraPrefix + ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
        }
    }
}
