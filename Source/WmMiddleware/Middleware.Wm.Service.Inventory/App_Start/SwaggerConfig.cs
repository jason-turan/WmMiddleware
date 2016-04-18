using System.Web.Http;
using WebActivatorEx;
using Middleware.Wm.Service.Inventory;
using Swashbuckle.Application;
using System;
namespace Middleware.Wm.Service.Inventory
{
    public class SwaggerConfig
    { 
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Middleware.Inventory");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.DescribeAllEnumsAsStrings();                        
                    })
                .EnableSwaggerUi(c =>{});
        }

        protected static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\bin\{1}.xml", 
                AppDomain.CurrentDomain.BaseDirectory,
                typeof(SwaggerConfig).Assembly.GetName().Name);
        }
    }
}