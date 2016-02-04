using Middleware.Jobs;
using MiddleWare.Log;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly ILog _log;

        public AuroraShipmentJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Info("Hello");
        }
    }
}
