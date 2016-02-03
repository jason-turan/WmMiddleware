namespace Middleware.Scheduler.WindowService.Scheduler
{
    public interface IServer
    {
        void StartJobs();

        void StopJobs();

        void PauseJobs();
    }
}
