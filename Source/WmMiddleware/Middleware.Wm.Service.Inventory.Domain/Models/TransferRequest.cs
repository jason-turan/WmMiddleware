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
        public List<ProductQuantity> ProductsToTransfer { get; set; } = new List<ProductQuantity>();
        [Required]
        public string FromStoreId { get; set; }
        [Required]
        public string ToStoreId { get; set; }

        [Required]
        public Location FromLocation { get; set; }
        [Required]
        public Location ToLocation { get; set; }

        public TransferRequest(TransferType type,
                               List<ProductQuantity> productsToTransfer,
                               string fromStoreId, Location fromLocation,
                               string toStoreId, Location toLocation)
        {
            TransferType = type;
            ProductsToTransfer = productsToTransfer;
            FromStoreId = fromStoreId;
            FromLocation = fromLocation;
            ToStoreId = toStoreId;
            ToLocation = toLocation;
        }
    }
}
