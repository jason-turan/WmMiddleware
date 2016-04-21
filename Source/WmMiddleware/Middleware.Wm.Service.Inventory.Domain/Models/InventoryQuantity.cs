using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// Object referencing a specific product, the quantities related to it, the location it is currently in, and the site that owns it.
    /// </summary>
    public partial class InventoryQuantity
    {
        [Required]
        public string StoreId { get; set; }

        [Required]
        public string LocationId { get; set; }

        [Required]
        public Product Product { get; set; }
        
        [Required]
        public int QuantityOnHand { get; set; }
        
        [Required]
        public int QuantityAvailableToSell { get; set; }

        public InventoryQuantity(string storeId, string locationId, 
                                 Product product, int qtyOnHand, 
                                 int qtyAvailableToSell)
        {
            StoreId = storeId;
            LocationId = locationId;
            Product = product;
            QuantityOnHand = qtyOnHand;
            QuantityAvailableToSell = qtyAvailableToSell;
        } 
    }
}
