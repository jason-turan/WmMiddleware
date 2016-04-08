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
    /// Action Item - additional detail needed, source and dest detail for a PO Kyle to find out the PO data structure
    /// </summary>
    public partial class TransferRequest
    {
        /// <summary>
        /// The type of transfer being executed, these types have potential impact on the integration or workflow executed.
        /// </summary>        
        /// <value>The type of transfer being executed, these types have potential impact on the integration or workflow executed.</value>        
        [Required]
        public TransferType TransferType { get; set; }

        [Required]
        public List<ProductQuantity> ProductsToTransfer { get; set; }

        public Store FromStore { get; set; }
        public Store ToStore { get; set; }

        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }

        public TransferRequest(TransferType type,
                               List<ProductQuantity> productsToTransfer,
                               Store fromStore, Location fromLocation,
                               Store toStore, Location toLocation)
        {
            TransferType = type;
            ProductsToTransfer = productsToTransfer;
            FromStore = fromStore;
            FromLocation = fromLocation;
            ToStore = toStore;
            ToLocation = toLocation;
        }
    }
}
