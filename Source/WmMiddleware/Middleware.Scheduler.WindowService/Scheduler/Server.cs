using Ninject;
using Quartz;
using Quartz.Spi;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Scheduler.WindowService.DependencyInjection;

namespace Middleware.Scheduler.WindowService.Scheduler
{
    public class Server : IServer
    {
        private readonly IScheduler _scheduler;
        private readonly ILog _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IServerScheduler _serverScheduler;

        public Server(ISchedulerFactory schedulerFactory, 
                      ILog logger, 
                      IJobFactory jobFactory,
                      IJobRepository jobRepository,
                      IServerScheduler serverScheduler)
        {
            _scheduler = schedulerFactory.GetScheduler();
            _scheduler.JobFactory = jobFactory;
            _jobRepository = jobRepository;
            _serverScheduler = serverScheduler;
            _logger = logger;
        }

        public void StartJobs()
        {
            _scheduler.Start();
            _scheduler.ListenerManager.AddTriggerListener(new TriggerListener(_jobRepository, _logger));
            _serverScheduler.ScheduleJobs(_scheduler);
            
            _logger.Info("Jobs started");
        }

        public void StopJobs()
        {
            _scheduler.Shutdown();

            var jobs = _jobRepository.GetJobs();
            foreach (var middlewareJob in jobs)
            {
                middlewareJob.NextRunDateTime = null;
                _jobRepository.UpdateJob(middlewareJob);
            }

            _logger.Info("Jobs shut down");
        }

        public void PauseJobs()
        {
          _scheduler.Standby();
          _logger.Info("Jobs paused");
        }

        public IScheduler Instance()
        {
            return _scheduler;
        }
        
        public static IServer BootStrap()
        {
            var kernel = new StandardKernel(new NinjectSettings { LoadExtensions = false },
                                            new NinjectModuleConfiguration());

            kernel.Get<ILog>().Debug("Ninject kernel configured.  Scheduler and logging are loaded.");

            return kernel.Get<IServer>();
        }
    }
}
