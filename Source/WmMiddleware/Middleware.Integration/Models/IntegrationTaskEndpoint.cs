using System.Collections.Generic;

namespace Middleware.Integration.Models
{
    public class IntegrationTaskEndpoint
    {
        public IntegrationTaskEndpointType EndpointType { get; set; }
        public IList<IntegrationTaskEndpointConfiguration> EndpointConfigurations { get; set; }
    }
}
