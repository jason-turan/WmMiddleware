using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;

namespace Middleware.Log
{
    public class Log4Net : ILog
    {
        private readonly log4net.ILog _logger;

        public Log4Net()
        {
            XmlConfigurator.Configure();
            AlterLogPathToRootPath();
            _logger = LogManager.GetLogger(AppDomain.CurrentDomain.FriendlyName);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Exception(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Exception(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        /// <summary>
        /// Change log path to path root of executing codebase (if installed on D drive, log to D drive)
        /// </summary>
        private static void AlterLogPathToRootPath()
        {
            var pathRoot = Path.GetPathRoot(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty)); 

            var hierarchy = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();

            foreach (IAppender a in hierarchy.Root.Appenders)
            {
                var appender = a as FileAppender;
                if (appender == null) continue;

                FileAppender fa = appender;

                string logFileLocation = fa.File.Replace(@"C:\", pathRoot);
                
                fa.File = logFileLocation;
                fa.ActivateOptions();
                break;
            }
        }
    }
}
