using Middleware.Integration.Models;

namespace Middleware.Integration.Repositories
{
    public interface IIntegrationTaskRespository
    {
        IntegrationTask GetTask(int jobId);
    }
}
