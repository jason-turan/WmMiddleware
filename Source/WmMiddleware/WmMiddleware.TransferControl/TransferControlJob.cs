using System;
using System.IO;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Control;

namespace WmMiddleware.TransferControl
{
    public class TransferControlJob : ITransferControlJob
    {
        private readonly ITransferControlOutbound _transferTransferControlOutbound;
        private readonly ITransferControlInbound _transferTransferControlInbound;
        private readonly IConfigurationManager _configurationManager;

        public TransferControlJob(IConfigurationManager configurationManager,
                                  ITransferControlInbound transferControlInbound,
                                  ITransferControlOutbound transferControlOutbound)
        {
            _configurationManager = configurationManager;
            _transferTransferControlOutbound = transferControlOutbound;
            _transferTransferControlInbound = transferControlInbound;
        }

        public void RunUnitOfWork(string args)
        {
            SetDirectories();

            var outboundSuccess = _transferTransferControlOutbound.Process();

            var inboundSuccess = _transferTransferControlInbound.Process();

            // throw if anything failed so job is marked as a partial failure
            if (!outboundSuccess)
            {
                throw new Exception("At least one outbound batch failed processing");
            }

            if (!inboundSuccess)
            {
                throw new Exception("At least one inbound batch failed processing");
            }
        }

        public void SetDirectories()
        {
            Directory.CreateDirectory(_configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileDirectory));
            Directory.CreateDirectory(_configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileProcessedDirectory));
            Directory.CreateDirectory(_configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory));
            Directory.CreateDirectory(_configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory));
            Directory.CreateDirectory(_configurationManager.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename));
        }
    }
}
