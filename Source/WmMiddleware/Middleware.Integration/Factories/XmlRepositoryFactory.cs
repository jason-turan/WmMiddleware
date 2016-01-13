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
                case IntegrationTaskEndpointType.GreatPlains:
                default:
                    throw new NotImplementedException();
            }
        }

        public IXmlWriteRepository CreateWriter(IntegrationTaskEndpoint destination)
        {
            switch (destination.EndpointType)
            {
                case IntegrationTaskEndpointType.GreatPlains:
                    return new GreatPlainsCommand();
                case IntegrationTaskEndpointType.File:
                    var directory = destination.EndpointConfigurations.Single(f => f.ConfigurationType == IntegrationTaskEndpointConfigurationType.Directory).ConfigurationValue;
                    var filename = destination.EndpointConfigurations.Single(f => f.ConfigurationType == IntegrationTaskEndpointConfigurationType.Filename).ConfigurationValue;
                    return new XmlFileCommand(directory, filename);
                case IntegrationTaskEndpointType.Database:
                case IntegrationTaskEndpointType.WebService:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
