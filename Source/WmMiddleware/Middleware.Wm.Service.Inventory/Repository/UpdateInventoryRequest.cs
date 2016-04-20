using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class UpdateInventoryRequest
    {
        public ProductQuantity Quantity {get;set;}
        public string SiteId { get; set; }
    }
}
