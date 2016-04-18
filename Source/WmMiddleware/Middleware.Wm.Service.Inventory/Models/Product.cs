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
        
        [Required]
        public string Style { get; set; }

        [Required]
        public string Size { get; set; }
        
        [Required]
        public string Width { get; set; }

        [Required]
        public string SeasonYear { get; set; }

        public Product(string upc, string style, string size, string width , string seasonYear)
        {
            UPC = upc;
            Style = style;
            Size = size;
            Width = width;
            SeasonYear = seasonYear;
        }
    }
}
