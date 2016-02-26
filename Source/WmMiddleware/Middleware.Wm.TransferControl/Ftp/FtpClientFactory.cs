using Middleware.Log;
using Middleware.Wm.TransferControl.Models;

namespace Middleware.Wm.TransferControl.Ftp
{
    public class FtpClientFactory : IFtpClientFactory
    {
        private readonly IFtpClientConfiguration _configuration;
        private readonly ILog _log;

        public FtpClientFactory(IFtpClientConfiguration configuration, ILog log)
        {
            _configuration = configuration;
            _log = log;
        }

        public IFtpClient CreateFtpClient()
        {
            return new FtpClient(GetFtpOptions(), _log);
        }

        private FtpOptions GetFtpOptions()
        {
            return new FtpOptions
            {
                Host = _configuration.GetHost(),
                UserId = _configuration.GetUsername(),
                Password = _configuration.GetPassword(),
                UseBinary = false
            };
        }
    }
}
