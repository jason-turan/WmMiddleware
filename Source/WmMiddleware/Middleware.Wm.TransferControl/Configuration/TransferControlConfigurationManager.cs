using Middleware.Jobs.Models;
using Middleware.Wm.Configuration;

namespace Middleware.Wm.TransferControl.Configuration
{
    public class TransferControlConfigurationManager : ITransferControlConfigurationManager
    {
        private readonly IConfigurationManager _configurationManager;

        public TransferControlConfigurationManager(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public JobType GetInboundJobType()
        {
            return JobType.ManhattanInbound;
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
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);
        }

        public string GetInboundFileProcessedDirectory()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory);
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

        public string GetInboundMasterFileFtpLocation()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
        }

        public bool IsFtpEnabled()
        {
            return _configurationManager.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable);
        }
    }
}
