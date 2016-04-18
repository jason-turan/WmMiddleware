using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.RibaSystem
{
    public interface IRibaSystem
    {
        void ReceivedOnLocation(PurchaseOrder po);        
    }
}