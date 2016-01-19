using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmMiddleware.StlInventoryUpdate.Models
{
    public class InventoryProcessing
    {

        public int ProcessingId { get; set; }

        public int ManhattanId { get; set; }

        public DateTime ProcessedDate { get; set; }

    }
}
