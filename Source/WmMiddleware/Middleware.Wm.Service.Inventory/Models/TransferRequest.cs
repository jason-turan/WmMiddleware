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
        
        public ILocation FromLocation { get; set; }
        public ILocation ToLocation { get; set; }

        public TransferRequest(TransferType type,
                               List<ProductQuantity> productsToTransfer,
                               ILocation fromLocation,
                               ILocation toLocation)
        {
            TransferType = type;
            ProductsToTransfer = productsToTransfer;
            FromLocation = fromLocation;
            ToLocation = toLocation;
        }
    }
}
