using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <remarks>
    /// A specified quantity of a sellable product. See also <seealso cref="Product"/>
    /// </remarks>
    public class ProductQuantity : Product
    {
        public ProductQuantity(string upc,int quantity)
            : base(upc)
        {
            Quantity = quantity;
        }
        
        [Required]
        public int Quantity { get; set; }
    }
}