using System.Collections.Generic;
using WmMiddleware.PixReturn.Models;

namespace WmMiddleware.PixReturn.Repository
{
    public interface IManhattanConditionCodeRepository
    {
        IEnumerable<ManhattanConditionCode> GetConditionCodes();
    }
}
