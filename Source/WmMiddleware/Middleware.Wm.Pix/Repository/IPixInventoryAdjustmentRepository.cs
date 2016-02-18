using System.Collections.Generic;
using Middleware.Wm.Pix.Models;

namespace Middleware.Wm.Pix.Repository
{
    public interface IPixInventoryAdjustmentRepository
    {
        IEnumerable<PixInventoryAdjustment> GetUnprocessedInventoryAdjustments();
    }
}
