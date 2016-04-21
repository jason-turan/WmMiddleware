using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Extensions
{
    public static class StringExtensions
    {
        
        public static bool EqualsIgnoreCase(this string thisString, string thatString)
        {
            return String.Equals(thisString, thatString, StringComparison.CurrentCultureIgnoreCase);
}


    }
}
