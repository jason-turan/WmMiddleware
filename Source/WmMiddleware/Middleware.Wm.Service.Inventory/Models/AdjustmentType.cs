using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Middleware.Wm.Service.Inventory.Models
{
    public enum AdjustmentType
    {
        UntrackedSale,
        CycleCount,
        Gifted,
        Destroyed
    }
}