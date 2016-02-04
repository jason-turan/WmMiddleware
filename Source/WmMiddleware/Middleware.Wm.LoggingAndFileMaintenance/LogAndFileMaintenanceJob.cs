using Middleware.Jobs;
using MiddleWare.Log;

namespace Middleware.Wm.LoggingAndFileMaintenance
{
    public class LogAndFileMaintenanceJob : IUnitOfWork
    {
        private readonly ILog _log;

        public LogAndFileMaintenanceJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Warning("I'm gonna clean some files and logs up!");
        }
    }
}
