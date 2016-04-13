namespace Middleware.Wm.TransferControl.Ftp
{
    public interface IFtpClientFactory
    {
        IFtpClient CreateFtpClient();
    }
}
