using MiddleWare.Log;

namespace WmMiddleware.PixReturn
{
    public class PixReturnJob : IPixReturnJob
    {
        private readonly ILog _log;

        public PixReturnJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Debug("this works");
        }
    }
}
