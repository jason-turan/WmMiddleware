using System.Web.Http;
using WebActivatorEx;
using Middleware.Wm.Service.Inventory;
using Swashbuckle.Application;
using System;
using System.Xml.Linq;
using System.Web;
using System.IO;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Filters;

namespace Middleware.Wm.Service.Inventory
{
    public class SwaggerConfig
    {
        public static void Register(HttpServerUtility server)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            var swaggerDocumentationPath = server.MapPath("~/bin/Middleware.Wm.Service.Inventory.Swagger.xml");            
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.ApiKey("AuthenticationToken")
                     .Description("Token provided by New Balance to authorize access to the service.")
                     .Name("AuthenticationToken")
                     .In("header");

                    c.SingleApiVersion("v1", "Middleware.Inventory");
                    c.IncludeXmlComments(swaggerDocumentationPath);
                    c.DescribeAllEnumsAsStrings();
                    
                })
                .EnableSwaggerUi(c => { });
        }

       
 
    }
}