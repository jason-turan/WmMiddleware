using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization; 

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// Represents an adjustment to physical inventory that was initited by the warehouse. 
    /// </summary>
    public partial class PhysicalAdjustment  
    { 
        public List<ProductQuantity> ProductQuantities { get; set; }
        public AdjustmentType? AdjustmentType { get; set; }

        public PhysicalAdjustment(AdjustmentType? type, List<ProductQuantity> productQuantities)
        { 
            this.AdjustmentType = type;
            this.ProductQuantities = productQuantities;    
        }        
    }
}
