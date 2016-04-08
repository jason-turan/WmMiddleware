using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization; 
using System.ComponentModel.DataAnnotations;

namespace NB.DTC.Aptos.InventoryService.Models
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

        public Product(string upc, string style, string size, string width )
        {
            this.UPC = upc;
            this.Style = style;
            this.Size = size;
            this.Width = width;            
        }


        

         
    }
}
