using System.Collections.Generic;
using Middleware.Wm.PixReturn.Models;

namespace Middleware.Wm.PixReturn.Repository
{
    public interface IManhattanConditionCodeRepository
    {
        IEnumerable<ManhattanConditionCode> GetConditionCodes();
    }
}
