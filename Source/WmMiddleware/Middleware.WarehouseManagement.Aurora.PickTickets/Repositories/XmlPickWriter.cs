using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Middleware.WarehouseManagement.Aurora.PickTickets.Models;
using WmMiddleware.Configuration;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public class XmlPickWriter : IPickWriter
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Order>), new XmlRootAttribute("Orders"));

        public XmlPickWriter(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            var filepath = @"C:\Test.xml";
            var writer = new StreamWriter(filepath);
            _serializer.Serialize(writer, orders.ToList());
        }
    }
}
