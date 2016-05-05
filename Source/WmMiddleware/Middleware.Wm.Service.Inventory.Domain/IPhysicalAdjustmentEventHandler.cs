using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IPhysicalAdjustmentEventHandler
    {
        void PhysicalInventoryChanged(List<PhysicalAdjustment> adjustments);
    }
}
