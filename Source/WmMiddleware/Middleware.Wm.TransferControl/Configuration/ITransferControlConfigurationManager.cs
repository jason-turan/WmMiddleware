using Middleware.Jobs.Models;

namespace WmMiddleware.TransferControl.Configuration
{
    public interface ITransferControlConfigurationManager
    {
        JobType GetInboundJobType();
        string GetOutboundFileDirectory();
        string GetOutboundFileProcessedDirectory();
        string GetInboundFileDirectory();
        string GetInboundFileProcessedDirectory();
        string GetInboundMasterControlFilename();
        string GetOutboundMasterControlFilename();
        string GetInboundFtpLocation();
        string GetInboundFtpUsername();
        bool IsFtpEnabled();
    }
}
