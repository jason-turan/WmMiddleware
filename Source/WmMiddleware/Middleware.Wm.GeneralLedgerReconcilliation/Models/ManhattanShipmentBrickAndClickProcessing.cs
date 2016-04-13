using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    [Table("ManhattanShipmentBrickAndClickProcessing")]
    public class ManhattanShipmentBrickAndClickProcessing
    {
        public string PickticketControlNumber { get; set; }
        public string BatchControlNumber { get; set; }
        public string ProcessedDate { get; set; }
    }
}
