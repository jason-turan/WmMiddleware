using Middleware.Wm.Service.Inventory.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace Middleware.Wm.Service.Inventory.Filters
{
    public class LogExceptionHander:ExceptionHandler
    {
        private ILogger _logger;

        public LogExceptionHander(ILogger logger)
        {
            _logger = logger;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            base.Handle(context);            
            _logger.Exception(context.Exception);
        }

    }
}