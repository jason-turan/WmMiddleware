using System;
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
                Subject = string.Concat(@"Cancelled\Incomplete Shipment - Cancelled - ", orderMap.OmsOrderNumber)
            };

            foreach (var toAddress in distribution.DistributionList.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(new MailAddress(toAddress.Trim()));
            }

            if (distribution.AdministrationSiteLink == string.Empty)
            {
                message.Body = "<p>Order Number " + orderMap.OmsOrderNumber + " was not shipped complete. The following items were cancelled and not shipped on the order:</p>Order Number: " + orderMap.OmsOrderNumber + "<br />";
            }
            else
            {
                message.Body = "<p>Order Number <a href=\"" + distribution.AdministrationSiteLink + orderMap.OmsOrderNumber + "\">" + orderMap.OmsOrderNumber + "</a>  was not shipped complete. The following items were cancelled and not shipped on the order:</p>";
            }

            message.Body += "</table>";

            message.Body += @"<table style='border: 1px solid black;'>
                                <tr>
                                        <th style='border: 1px solid black;' bgcolor='#b3b3b3'>Line</th>
                                        <th style='border: 1px solid black;' bgcolor='#b3b3b3'>Item</th>
                                        <th style='border: 1px solid black;' bgcolor='#b3b3b3'>SKU</th>
                                        <th style='border: 1px solid black;' bgcolor='#b3b3b3'>Pick Quantity</th>
                                        <th style='border: 1px solid black;' bgcolor='#b3b3b3'>Shipped Quantity</th>
                                </tr>";

            foreach (var cancel in cancellation)
            {
                message.Body += "<tr style='border: 1px solid black;'><td style='border: 1px solid black;'>" + cancel.LineNumber +
                                "</td><td style='border: 1px solid black;'>" + cancel.Style +
                                "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td style='border: 1px solid black;'>" + cancel.StockKeepingUnit + 
                                "</td>" +
                                "<td style='border: 1px solid black;'>" + cancel.PickQuantity.Replace(".0000", string.Empty) + "</td>" +
                                "<td style='border: 1px solid black;'>" + cancel.ShippedQuantity.Replace(".0000", string.Empty) + "</td>" +
                                "</tr>"; 
            }
            
            message.Body += "</table>";

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }
    }
}
