namespace WmMiddleware.TransferControl.Ftp
{
    public interface IFtpClientConfiguration
    {
        string GetHost();
        string GetPassword();
        string GetUsername();
    }
}
