using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NB.DTC.Aptos.InventoryService.Models
{
    /// <remarks>
    /// A specified quantity of a sellable product. See also <seealso cref="Product"/>
    /// </remarks>
    public class ProductQuantity:Product
    {
        public ProductQuantity(string upc, string style, string size, string width, int quantity)
            :base(upc, style, size,width)
        {
            this.Quantity = quantity;
        }
        public ProductQuantity(ProductQuantity pq) : this(pq.UPC, pq.Style, pq.Size, pq.Width, pq.Quantity) { }        
        public ProductQuantity(ProductQuantity pq, int newQuantity) :this(pq.UPC, pq.Style, pq.Size, pq.Width,newQuantity){}

        public int Quantity { get; set; }
    }
}