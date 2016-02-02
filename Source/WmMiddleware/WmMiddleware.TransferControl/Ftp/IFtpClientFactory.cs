namespace WmMiddleware.TransferControl.Ftp
{
    public interface IFtpClientFactory
    {
        IFtpClient CreateFtpClient();
    }
}
