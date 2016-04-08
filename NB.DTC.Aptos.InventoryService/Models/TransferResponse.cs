using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NB.DTC.Aptos.InventoryService.Models
{
    public class TransferResponse
    {
        [Required]
        public List<ProductQuantity> QuantitiesTransferred { get; set; }
    }
}