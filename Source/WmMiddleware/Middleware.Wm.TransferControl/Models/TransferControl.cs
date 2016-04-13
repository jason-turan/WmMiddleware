using System;
using System.Collections.Generic;

namespace Middleware.Wm.TransferControl.Models
{
    public class TransferControl
    {
        public int TransferControlId { get; set; }

        public int JobId { get; set; }

        public string BatchControlNumber { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public IList<TransferControlFile> Files { get; set; }
    }
}