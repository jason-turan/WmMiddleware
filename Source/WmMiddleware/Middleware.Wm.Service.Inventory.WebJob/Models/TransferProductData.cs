using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.WebJob.Models
{
    public class TransferProductData
    {
        public List<ProductQuantity> ProductsTransferred { get; set; }
        public string GainingStoreId { get; set; }
        //public TransferType TransferType { get; set; }
        //public List<ProductQuantity> ProductsToTransfer { get; set; } = new List<ProductQuantity>();
        //public string FromStoreId { get; set; }
        //public string ToStoreId { get; set; }
        //public Location FromLocation { get; set; }
        //public Location ToLocation { get; set; }
    }
}
