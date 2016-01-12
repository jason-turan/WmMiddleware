using MiddleWare.Log;

namespace WmMiddleware.ProductReturn
{
    public class ProductReturnJob : IProductReturnJob
    {
        private readonly ILog _log;

        public ProductReturnJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Debug("this works");
        }
    }
}
