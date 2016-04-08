using System.Web.Http;
using WebActivatorEx;
using NB.DTC.Aptos.InventoryService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace NB.DTC.Aptos.InventoryService
{
    public class SwaggerConfig
    { 
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "NB.DTC.Aptos.InventoryService");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.DescribeAllEnumsAsStrings();                        
                    })
                .EnableSwaggerUi(c =>{});
        }
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\{1}.xml", 
                System.AppDomain.CurrentDomain.BaseDirectory,
                typeof(SwaggerConfig).Assembly.GetName().Name);
        }
    }
}
