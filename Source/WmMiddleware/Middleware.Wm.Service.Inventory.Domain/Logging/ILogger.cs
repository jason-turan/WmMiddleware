using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Logging
{
    //Adding logger interface in case we want to switch out logging to a framework later.
    //Currently we are simply logging using the System.Diagnostics namespace which will 
    //Write to an table storage object 
    public interface ILogger
    {        
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Exception(Exception exception);
        void Exception(string message, Exception exception);
    }
}
