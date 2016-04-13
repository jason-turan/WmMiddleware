using System.ServiceProcess;
using Middleware.Scheduler.WindowService.Scheduler;

namespace Middleware.Scheduler.WindowService
{
    public partial class WindowsServiceScheduler : ServiceBase
    {
        private readonly IServer _scheduler;

        public WindowsServiceScheduler()
        {
            InitializeComponent();
            _scheduler = Server.BootStrap();
        }

        protected override void OnStart(string[] args)
        {  
            _scheduler.StartJobs();
        }

        protected override void OnStop()
        {
            _scheduler.StopJobs();
        }

        protected override void OnPause()
        {
            _scheduler.PauseJobs();
            base.OnPause();
        }
    }
}
