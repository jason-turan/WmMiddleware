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
            this.StoreId = storeId;
            this.LocationId = locationId;
            this.Product = product;
            this.QuantityOnHand = qtyOnHand;
            this.QuantityAvailableToSell = qtyAvailableToSell;
        } 
    }
}
