using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models
{
    public class PurchaseOrderReceipt
    {
        public TransactionType TransactionType { get; set; } 
        public DateTime ReceiveDate { get; set; }
        public String PONo { get; set; }        
    }
}
