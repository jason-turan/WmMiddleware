using System;
using System.Linq;
using Middleware.Integration.Models;
using Middleware.Integration.Repositories;

namespace Middleware.Integration.Factories
{
    public class XmlRepositoryFactory : IXmlRepositoryFactory
    {
        public IXmlReadRepository CreateReader(IntegrationTaskEndpoint source)
        {
            switch (source.EndpointType)
            {
                case IntegrationTaskEndpointType.Database:
                    var connectionString = source.EndpointConfigurations.Single(f => f.ConfigurationType == IntegrationTaskEndpointConfigurationType.Connection).ConfigurationValue;
                    var commandText = source.EndpointConfigurations.Single(f => f.ConfigurationType == IntegrationTaskEndpointConfigurationType.CommandText).ConfigurationValue;
                    return new XmlDatabaseCommand(connectionString, commandText);
                case IntegrationTaskEndpointType.File:
                case IntegrationTaskEndpointType.WebService:
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public IXmlWriteRepository CreateWriter(IntegrationTaskEndpoint destination)
        {
            throw new NotImplementedException();
        }
    }
}
