using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// List of values to use as query parameters for inventory. Use \&quot;*\&quot; to represent all possible values or an array of values to include multiple values.
    /// </summary>
    public class InventorySearchFilter 
    {                 
        public IEnumerable<string> SiteIds { get; set; }
        public IEnumerable<string> LocationIds { get; set; }
        public IEnumerable<string> Styles { get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public IEnumerable<string> Widths { get; set; }
        public IEnumerable<string> UPCs { get; set; }
                
    }
}
