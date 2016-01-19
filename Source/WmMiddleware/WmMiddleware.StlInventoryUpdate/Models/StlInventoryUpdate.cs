using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmMiddleware.StlInventoryUpdate.Models
{
    public class StlInventoryUpdate
    {
        
        public int ProcessingId { get; set; }

        public string Upc { get; set; }

        public string Style { get; set; }

        public string Size { get; set; }

        public string Attr { get; set; }

        public int Qty { get; set; }

        public DateTime? InvDate { get; set; }

    }
}
