using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// Unique definition of a sellable product.
    /// </summary>
    public partial class Product  
    {
        [Required]
        public string UPC { get; set; }

        public Product() { }

        public Product(string upc)
        {
            UPC = upc; 
        }
    }
}
