using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Middleware.Wm.Service.Inventory.Models
{
    public class HealthCheckModel
    {        
        public List<ComponentCheckModel> Components { get; set; }
        public bool Running { get; set; }
        public string Version { get; set; }
    }
}