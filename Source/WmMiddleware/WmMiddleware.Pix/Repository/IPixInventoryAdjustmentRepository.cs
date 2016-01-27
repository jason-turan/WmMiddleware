using System.Collections.Generic;
using WmMiddleware.Pix.Models;

namespace WmMiddleware.Pix.Repository
{
    public interface IPixInventoryAdjustmentRepository
    {
        IEnumerable<PixInventoryAdjustment> GetUnprocessedInventoryAdjustments();
    }
}
