using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models;

namespace Middleware.Wm.Service.Inventory.Domain.Logging
{
    //Adding logger interface in case we want to switch out logging to a framework later.
    //Currently we are simply logging using the System.Diagnostics namespace. The Azure site is 
    //configured to write to a table storage
    public interface ILogger
    {
        void DumpInfo<TCaller>(object obj, string callerName = "");
        void DumpInfo(object obj, string callerName = "");
        void Info(string message);

        void DumpWarning<TCaller>(string warningMessage, object[] objectsToDump, string callerName = "");
        void Warning(string message);
        void Error(string message);
        void Exception(Exception exception);
        void Exception(string message, Exception exception);
        
    }
}
