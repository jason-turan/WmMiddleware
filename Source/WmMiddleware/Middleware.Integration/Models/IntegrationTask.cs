namespace Middleware.Integration.Models
{
    public class IntegrationTask
    {
        public int IntegrationTaskId { get; set; }
        public int JobId { get; set; }
        public int Sequence { get; set; }
        public int SourceTypeId { get; set; }
        public int DestinationTypeId { get; set; }
        public IntegrationTaskEndpoint Source { get; set; }
        public IntegrationTaskEndpoint Destination { get; set; }
        public string XsltTransformName { get; set; }
    }
}
