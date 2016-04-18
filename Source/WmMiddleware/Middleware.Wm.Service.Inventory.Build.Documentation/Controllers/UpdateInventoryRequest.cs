namespace Middleware.Wm.Service.Inventory.Models.Controllers
{
    public class UpdateInventoryRequest
    {
        public ProductQuantity Quantity { get; set; }
        public string SiteId { get; set; }
    }
}