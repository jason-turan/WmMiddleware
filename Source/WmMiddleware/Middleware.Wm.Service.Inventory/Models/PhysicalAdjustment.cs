using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization; 

namespace NB.DTC.Aptos.InventoryService.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PhysicalAdjustment  
    { 
        public List<ProductQuantity> ProductQuantities { get; set; }
        public AdjustmentType AdjustmentType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAdjustment" /> class.
        /// </summary>
        /// <param name="type">The type of adjustment being made. (default to &quot;cycle&quot;).</param>       
        public PhysicalAdjustment(AdjustmentType type, List<ProductQuantity> productQuantities)
        {
            // use default value if no "AdjustmentType" provided
            this.AdjustmentType = type;
            this.ProductQuantities = productQuantities;    
        }        
    }
}
