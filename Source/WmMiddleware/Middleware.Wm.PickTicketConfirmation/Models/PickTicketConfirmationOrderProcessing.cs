using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.PickTicketConfirmation.Models
{
    [Table("PickTicketConfirmationOrderProcessing")]
    public class PickTicketConfirmationOrderProcessing
    {
        public string OrderNumber { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string ControlNumber { get; set; }
    }
}
