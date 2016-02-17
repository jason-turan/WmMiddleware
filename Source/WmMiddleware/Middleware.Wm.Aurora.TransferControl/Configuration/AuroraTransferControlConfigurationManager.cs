using System.Collections.Generic;
using Middleware.Jobs;
using Middleware.Jobs.Models;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Configuration;

namespace Middleware.WM.Aurora.TransferControl.Configuration
{
    public class AuroraTransferControlConfigurationManager : ITransferControlConfigurationManager
    {
        private readonly IConfigurationManager _configurationManager;
        private const string AuroraPrefix = "Aurora_";

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
    }
}
