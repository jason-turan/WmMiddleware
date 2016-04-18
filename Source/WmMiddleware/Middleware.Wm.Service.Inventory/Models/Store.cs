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
    public partial class Store 
    {
        public string StoreId { get; set; }
        public string AltId { get; set; }
        public StoreType StoreType { get; set; }

        public Store(string storeId, string altId, StoreType storeType)
        {
            StoreId = storeId;
            AltId = altId;
            StoreType = storeType;
        } 
    }
}
