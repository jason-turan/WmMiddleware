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
    public partial class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }

        public Location(
            string locationId, 
            string locationName, 
            string address)
        {
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.Address = address; 
        } 

    }
}
