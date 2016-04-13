using System.Collections.Generic;
using Middleware.Wm.Pix.Models;

namespace Middleware.Wm.Pix.Repository
{
    public interface IPixReturnRepository
    {
        IEnumerable<PixReturn> GetUnprocessedReturns();
    }
}
