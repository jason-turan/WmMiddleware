﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models;

namespace Middleware.Wm.Service.Inventory.Domain.RibaSystem
{
    public interface IRibaSystem
    {
        void SendPurchaseOrderReceipt(PurchaseOrderReceipt po);        
    }
}