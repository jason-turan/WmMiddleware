using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Middleware.Wm.Service.Inventory.Models
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

        [Required]
        public Store FromStore { get; set; }
        [Required]
        public Store ToStore { get; set; }

        [Required]
        public Location FromLocation { get; set; }
        [Required]
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
