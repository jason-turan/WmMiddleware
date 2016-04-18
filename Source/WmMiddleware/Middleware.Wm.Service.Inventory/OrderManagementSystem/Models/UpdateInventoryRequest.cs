using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem.Models
{
    public class UpdateInventoryRequest
    {
        public ProductQuantity Quantity {get;set;}
        public string SiteId { get; set; }
    }
}
