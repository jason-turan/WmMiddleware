using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.Aurora.Shipment.Models
{
    [Table("KioskOrderExportProcessing")]
    public class KioskOrderExportProcessing
    {
        [Key]
        int ProcessingId { get; set; }

        int KioskOrderProcessId { get; set; }

        DateTime ProcessedDate { get; set; }
    }
}
