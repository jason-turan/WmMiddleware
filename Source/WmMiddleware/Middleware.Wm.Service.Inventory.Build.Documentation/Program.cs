using Newtonsoft.Json;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.SelfHost;

namespace NB.DTC.Aptose.Build.Documentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8081");
                        
            config.Routes.MapHttpRoute("API Default",
                           "api/{controller}/{action}/{id}",
                           new { id = RouteParameter.Optional });

            config.EnableSwagger(c =>
            {
                c.MultipleApiVersions(
                   (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                   (vc) =>
                   {
                       vc.Version("Oms", "Oms");
                       vc.Version("Riba", "Riba");
                   });
            }).EnableSwaggerUi(c => {
                c.EnableDiscoveryUrlSelector();
            });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();             
                WriteSwaggerToFile("../../../Oms.Swagger.json", "http://localhost:8081/swagger/docs/Oms" );
                WriteSwaggerToFile("../../../Oms.Riba.json", "http://localhost:8081/swagger/docs/Riba");
                WriteSwaggerToFile("../../../InventoryService.json", "http://localhost:52520/swagger/docs/v1");
                Console.ReadLine();
            }
        }

        private static void WriteSwaggerToFile(string filePath, string url)
        {
            using (WebClient client = new WebClient())
            {
                string jsonString = client.DownloadString(url);
                var jsonObject =JsonConvert.DeserializeObject(jsonString);
                var formattedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(filePath, formattedJson);
                Console.WriteLine(String.Format("Wrote {0}", filePath));
            }
        }

        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            var matches = apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName.Contains(targetApiVersion);
            return matches;
        }
    }
}
