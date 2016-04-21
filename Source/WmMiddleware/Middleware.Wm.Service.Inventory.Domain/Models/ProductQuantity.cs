using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <remarks>
    /// A specified quantity of a sellable product. See also <seealso cref="Product"/>
    /// </remarks>
    public class ProductQuantity : Product
    {
        public ProductQuantity(string upc, string style, string size, string width, string seasonYear, int quantity)
            : base(upc, style, size, width, seasonYear)
        {
            this.Quantity = quantity;
        }

        public ProductQuantity() { }
        public ProductQuantity(ProductQuantity pq) : this(pq.UPC, pq.Style, pq.Size, pq.Width, pq.SeasonYear, pq.Quantity) { }
        public ProductQuantity(ProductQuantity pq, int newQuantity) : this(pq.UPC, pq.Style, pq.Size, pq.Width, pq.SeasonYear, newQuantity) { }

        [Required]
        public int Quantity { get; set; }
    }
}