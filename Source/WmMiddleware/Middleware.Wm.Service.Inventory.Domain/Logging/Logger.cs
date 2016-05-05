using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Logging
{
    public class Logger : ILogger
    {
        public void DumpInfo(object obj, [CallerMemberName] string callerName = "")
        {
            //TODO determine current trace level
            var sw = new StringWriter();
            sw.WriteLine(String.Format("Calling Method:{0}", callerName));
            ObjectDumper.Write(obj, 0, sw);
            Info(sw.ToString());            
        }

        public void DumpInfo<TCaller>(object obj, [CallerMemberName] string callerName = "")
        {            
            //TODO determine current trace level
            var sw = new StringWriter();
            sw.WriteLine(String.Format("Calling Type: {0} Calling Method:{0}", typeof(TCaller).Name, callerName));
            ObjectDumper.Write(obj, 0, sw);
            Info(sw.ToString());
        }

        public void DumpWarning<TCaller>(string warningMessage, object[] objectsToDump, [CallerMemberName] string callerName = "")
        { 
            var sw = new StringWriter();
            sw.WriteLine(String.Format("Calling Type: {0} Calling Method:{0}", typeof(TCaller).Name, callerName));
            ObjectDumper.Write(objectsToDump, 0, sw);
            Info(sw.ToString());
        }

        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Exception(Exception exception)
        {
            Error(exception == null ? "" : exception.ToString());
        }

        public void Exception(string message, Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine(exception.ToString());
            Error(sb.ToString());
        }

        public void Info(string message)
        {
            Trace.TraceInformation(message);
        }

        public void Warning(string message)
        {
            Trace.TraceInformation(message);
        }
    }

}
