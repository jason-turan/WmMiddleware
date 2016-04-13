using Middleware.Integration.Models;
using Middleware.Integration.Repositories;

namespace Middleware.Integration.Factories
{
    public interface IXmlRepositoryFactory
    {
        IXmlReadRepository CreateReader(IntegrationTaskEndpoint source);
        IXmlWriteRepository CreateWriter(IntegrationTaskEndpoint destination);
    }
}
