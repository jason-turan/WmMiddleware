﻿using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <remarks>
    /// A specified quantity of a sellable product. See also <seealso cref="Product"/>
    /// </remarks>
    public class ProductQuantity
    {
        public ProductQuantity() { }
        public ProductQuantity(Product p, int q) { Product = p; Quantity = q; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}