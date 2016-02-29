using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.ShipmentCancellationEmail.Models;
using Middleware.Wm.ShipmentCancellationEmail.Repository;

namespace Middleware.Wm.ShipmentCancellationEmail
{
    public class ShipmentCancellationEmailJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IConfigurationManager _configurationManager;
        private readonly ICancellationEmailDistributionRepository _cancellationEmailDistributionRepository;
        private readonly IOmsManhattanOrderMapRepository _omsManhattanOrderMapRepository;

        public ShipmentCancellationEmailJob(ILog log,
                                            IConfigurationManager configurationManager,
                                            ICancellationEmailDistributionRepository cancellationEmailDistributionRepository,
                                            IOmsManhattanOrderMapRepository omsManhattanOrderMapRepository)
        {
            _log = log;
            _configurationManager = configurationManager;
            _cancellationEmailDistributionRepository = cancellationEmailDistributionRepository;
            _omsManhattanOrderMapRepository = omsManhattanOrderMapRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var cancellations = _cancellationEmailDistributionRepository.GetShipmentEmailCancellations().ToList();

            if (!cancellations.Any())
            {
                _log.Info("No shipment line item cancellations to process");
            }
            else
            {
                _log.Info("Now processing " + cancellations.Count() + " line item shipment cancellations");

                foreach (var cancellation in cancellations.GroupBy(g => g.OrderNumber))
                {

                    var orderMap = _omsManhattanOrderMapRepository.GetOmsManhattanOrderMap(new OmsManhattanOrderMapFindCriteria{ ManhattanOrderNumber = cancellation.Key });

                    if (orderMap == null || orderMap.Company == null)
                    {
                        _log.Warning("Cannot find company for cancelled order " + cancellation.Key);
                    }
                    else
                    {
                        var distribution = _cancellationEmailDistributionRepository.GetShipmentCancellationEmailDistribution(orderMap.Company);
                        SendEmail(cancellation, orderMap, distribution);
                    }
                }

                _cancellationEmailDistributionRepository.SetAsProcessed(cancellations);
            }
        }

        private void SendEmail(IEnumerable<Models.ShipmentCancellationEmail> cancellation, 
                               OmsManhattanOrderMap orderMap, 
                               ShipmentCancellationEmailDistribution distribution)
        {
            var smptServer =
                _configurationManager.GetKey<string>(ConfigurationKey.SmptServer);

            var message = new MailMessage
            {
                From = new MailAddress("noreply@newbalance.com"),
                IsBodyHtml = true,
                Subject = string.Concat("Cancelled - ", orderMap.OmsOrderNumber)
            };

            message.To.Add(new MailAddress(distribution.DistributionList));

            if (distribution.AdministrationSiteLink == string.Empty)
            {
                message.Body = "<p>Order Number " + orderMap.OmsOrderNumber + " was cancelled.</p>Order Number: " + orderMap.OmsOrderNumber + "<br />";
            }
            else
            {
                message.Body = "<p>Order Number <a href=\"" + distribution.AdministrationSiteLink + orderMap.OmsOrderNumber + "\">" + orderMap.OmsOrderNumber + "</a> was cancelled.</p>";
            }

            message.Body += "</table>";

            message.Body += "<table><tr><td>Line</td><td>Item</td><td>SKU</td></tr>";

            //loop through line items
            foreach (var cancel in cancellation)
            {
                // TODO: remove cadre link
                message.Body += "<tr><td>" + cancel.LineNumber +
                                "</td><td><a href=\"http://cctools/Warehouse/InventoryLookup.aspx?style=" + cancel.Style + "\">" + cancel.Style + 
                                "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>" + cancel.StockKeepingUnit + 
                                "</td></tr>"; 
            }
            
            message.Body += "</table>";

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }
    }
}
