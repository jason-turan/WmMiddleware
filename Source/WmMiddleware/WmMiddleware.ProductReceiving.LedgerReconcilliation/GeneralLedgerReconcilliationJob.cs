using Middleware.Jobs;
using MiddleWare.Log;

namespace WmMiddleware.GeneralLedgerReconcilliation
{
    public class GeneralLedgerReconcilliationJob : IUnitOfWork
    {
        private readonly ILog _log;

        public GeneralLedgerReconcilliationJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Info("Initial Setup : I work");
        }
    }
}
