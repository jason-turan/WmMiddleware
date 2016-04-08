using NB.DTC.Aptos.InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem.Models
{
    public class UpdateInventoryRequest
    {
        public ProductQuantity Quantity {get;set;}
        public string SiteId { get; set; }
    }
}
