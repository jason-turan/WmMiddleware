namespace Middleware.Integration.Models
{
    public class IntegrationTask
    {
       public int IntegrationTaskId { get; set; }
       public int JobId { get; set; }
       public int Sequence { get; set; }
       public IntegrationTaskEndpointType SourceTypeId { get; set; }
       public IntegrationTaskEndpointType DestinationTypeId { get; set; }
       public IntegrationTaskEndpoint Source { get; set; }
       public IntegrationTaskEndpoint Destination { get; set; }
    }
}
