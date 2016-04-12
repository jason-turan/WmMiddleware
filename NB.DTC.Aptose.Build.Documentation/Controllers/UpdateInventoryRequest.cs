using NB.DTC.Aptos.InventoryService.Models;

namespace NB.DTC.Aptos.InventoryService.Tests.Controllers
{
    public class UpdateInventoryRequest
    {
        public ProductQuantity Quantity { get; set; }
        public string SiteId { get; set; }
    }
}