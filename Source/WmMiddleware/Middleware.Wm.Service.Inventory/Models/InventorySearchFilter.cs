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
    /// List of values to use as query parameters for inventory. Use \&quot;*\&quot; to represent all possible values or an array of values to include multiple values.
    /// </summary>
    public class InventorySearchFilter 
    {                 
        public List<string> StoreIds { get; set; }
        public List<string> LocationIds { get; set; }
        public List<string> Styles { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Widths { get; set; }
        public List<string> UPCs { get; set; }
                
    }
}
