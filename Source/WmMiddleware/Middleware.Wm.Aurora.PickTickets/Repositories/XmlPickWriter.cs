using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Middleware.Wm.Inventory;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Ftp;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public class XmlPickWriter : IPickWriter
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly IFtpClient _ftpClient;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Order>), new XmlRootAttribute("Orders"));

        public XmlPickWriter(IConfigurationManager configurationManager, IFtpClientFactory ftpClientfactory)
        {
            _configurationManager = configurationManager;
            _ftpClient = ftpClientfactory.CreateFtpClient();
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            var localDirectory = _configurationManager.GetKey<string>(ConfigurationKey.OmsAuroraLocalDirectory);
            var sftpDirectory = _configurationManager.GetKey<string>(ConfigurationKey.OmsAuroraSftpDirectory);

            var filename = string.Format("aurora_orders_{0:yyyy-MM-dd}_{0:hh-mm-ss}.xml", DateTime.Now);
            if (!Directory.Exists(localDirectory))
            {
                Directory.CreateDirectory(localDirectory);
            }

            var filepath = Path.Combine(localDirectory, filename);
            using (var writer = new StreamWriter(filepath))
            {
                _serializer.Serialize(writer, orders.ToList());
            }

            var sftpFilepath = Path.Combine(sftpDirectory, filename);
            _ftpClient.Upload(new FileInfo(filepath), sftpFilepath);
        }
    }
}
