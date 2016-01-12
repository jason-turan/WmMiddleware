using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WmMiddleware.ProductReceiving.Models
{
    public class PurchaseReturn
    {
        public PurchaseReturn()
        {
            Items = new Collection<LineItem>();
        }

        public ICollection<LineItem> Items { get; set; }

        public string ExternalUid { get; set; } 
    }
}
