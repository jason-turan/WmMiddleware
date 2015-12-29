using MiddleWare.Log;

namespace WmMiddleware.Pix
{
    public class PixJob : IPixJob
    {
        private readonly ILog _log;

        public PixJob(ILog log)
        {
            _log = log;
        }
        public void RunUnitOfWork()
        {
            _log.Info("Pix ran");
        }
    }
}
