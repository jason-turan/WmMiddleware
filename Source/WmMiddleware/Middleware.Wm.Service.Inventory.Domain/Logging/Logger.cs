using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.Logging
{
    public class Logger : ILogger
    {
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
