using MiddleWare.Log;

namespace WmMiddleware.ShipmentCancellationEmail
{
    public class ShipmentCancellationEmailJob : IShipmentCancellationEmailJob
    {
        private readonly ILog _log;

        public ShipmentCancellationEmailJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Debug("alive");
        }
    }
}
