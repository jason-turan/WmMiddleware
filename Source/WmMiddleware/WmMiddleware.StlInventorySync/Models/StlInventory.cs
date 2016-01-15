using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace WmMiddleware.StlInventorySync.Models
{
    [Table("StlInventory")]
    public class StlInventory
    {

        public string Upc { get; set; }

        public string Style { get; set; }

        public string Size { get; set; }

        public string Attr { get; set; }

        public int Qty { get; set; }

        public int InventorySyncProcessingId { get; set; }

        public DateTime InvDate { get; set; }

    }
}
