namespace Middleware.Wm.TransferControl.Ftp
{
    public class SftpClientFactory : IFtpClientFactory
    {
        private readonly IFtpClientConfiguration _configurationManager;

        public SftpClientFactory(IFtpClientConfiguration configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public IFtpClient CreateFtpClient()
        {
            return new SftpClient(_configurationManager.GetHost(), _configurationManager.GetUsername(), _configurationManager.GetPassword());
        }
    }
}
