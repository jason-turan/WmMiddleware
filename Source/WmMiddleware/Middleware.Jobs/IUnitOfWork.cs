namespace Middleware.Jobs
{
    public interface IUnitOfWork
    {
        void RunUnitOfWork(string jobKey);
    }
}
