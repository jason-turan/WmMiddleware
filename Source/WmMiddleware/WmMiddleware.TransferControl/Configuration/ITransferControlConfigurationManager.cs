namespace WmMiddleware.TransferControl.Configuration
{
    public interface ITransferControlConfigurationManager
    {
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
