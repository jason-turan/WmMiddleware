using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models
{
    public enum TransactionType
    {
        [EnumMember(Value = "PORcpt")]
        PurchaseOrderReceipt

        
    }
}
