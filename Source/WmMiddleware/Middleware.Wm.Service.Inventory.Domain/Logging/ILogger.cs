using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Logging
{
    //
    public interface ILogger
    {        
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Exception(Exception exception);
        void Exception(string message, Exception exception);
    }
}
