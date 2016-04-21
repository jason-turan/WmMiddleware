using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class UpdateInventoryRequest
    {
        public ICollection<ProductQuantity> ProductUpdateQuantities { get; set; } = new List<ProductQuantity>();
        public string SiteId { get; set; }
    }
}
