using System;
using System.IO;
using Middleware.Jobs;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;

namespace Middleware.Wm.TransferControl
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

        private short _value;

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!(value is short))
                {
                    if ((int)value == 0)
                    {
                        _value = 0;
                    }
                    else
                    {
                        throw new ArgumentException("Value must be of type short");
                    }
                }
                else
                {
                    _value = (short)value;
                }
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
