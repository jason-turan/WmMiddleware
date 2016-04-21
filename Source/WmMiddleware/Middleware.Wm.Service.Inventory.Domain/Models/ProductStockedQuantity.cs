using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Models
{
    public class ProductStockedQuantity
    {
        public String Upc { get; set; }
        public int Quantity { get; set; }
        public int UnstockedQuantity { get; set; }
    }
}
