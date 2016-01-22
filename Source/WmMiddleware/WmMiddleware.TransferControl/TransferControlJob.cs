using System;
using System.IO;
using Middleware.Jobs;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Configuration;
using WmMiddleware.TransferControl.Control;

namespace WmMiddleware.TransferControl
{
    public class TransferControlJob : IUnitOfWork
    {
        private readonly ITransferControlOutbound _transferTransferControlOutbound;
        private readonly ITransferControlInbound _transferTransferControlInbound;
        private readonly ITransferControlConfigurationManager _configurationManager;

        public TransferControlJob(ITransferControlConfigurationManager configurationManager,
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
            Directory.CreateDirectory(_configurationManager.GetOutboundFileDirectory());
            Directory.CreateDirectory(_configurationManager.GetOutboundFileProcessedDirectory());
            Directory.CreateDirectory(_configurationManager.GetInboundFileProcessedDirectory());
            Directory.CreateDirectory(_configurationManager.GetInboundFileDirectory());
            Directory.CreateDirectory(_configurationManager.GetInboundMasterControlFilename());
        }
    }
}
