using System.Collections.Generic;
using WmMiddleware.Pix.Models;

namespace WmMiddleware.Pix.Repository
{
    public interface IPixReturnRepository
    {
        IEnumerable<PixReturn> GetUnprocessedReturns();
    }
}
