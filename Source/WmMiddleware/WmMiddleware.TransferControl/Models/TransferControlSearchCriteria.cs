using Middleware.Jobs.Models;

namespace WmMiddleware.TransferControl.Models
{
    public class TransferControlSearchCriteria
    {
        public bool? Processed { get; set; }

        public int? JobId { get; set; }

        public JobType JobType { get; set; }
    }
}
