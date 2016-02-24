using System.Linq;
using System.Net.Mail;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.ShipmentCancellationEmail.Models;
using Middleware.Wm.ShipmentCancellationEmail.Repository;

namespace Middleware.Wm.ShipmentCancellationEmail
{
    public class ShipmentCancellationEmailJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IConfigurationManager _configurationManager;
        private readonly ICancellationEmailDistributionRepository _cancellationEmailDistributionRepository;

        public ShipmentCancellationEmailJob(ILog log, 
                                            IConfigurationManager configurationManager,
                                            ICancellationEmailDistributionRepository cancellationEmailDistributionRepository)
        {
            _log = log;
            _configurationManager = configurationManager;
            _cancellationEmailDistributionRepository = cancellationEmailDistributionRepository;
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
            }

            foreach (var cancellation in cancellations)
            {
                cancellation.Company = _cancellationEmailDistributionRepository.GetCompanyFromOrderNumber(cancellation.OrderNumber + "-" + cancellation.LineNumber);
                if (cancellation.Company == null)
                {
                    _log.Warning("Cannot find company for cancelled order " + cancellation.OrderNumber + "-" + cancellation.LineNumber);
                }
                else
                {
                    var distribution = _cancellationEmailDistributionRepository.GetShipmentCancellationEmailDistribution(cancellation.Company);
                    SendEmail(cancellation, distribution);    
                }
            }
        }

        private void SendEmail(Models.ShipmentCancellationEmail cancellation, ShipmentCancellationEmailDistribution distribution)
        {            
            var smptServer =
                _configurationManager.GetKey<string>(ConfigurationKey.SmptServer);
           
            var orderNumber = string.Concat(cancellation.OrderNumber, 
                                            "-", 
                                            cancellation.LineNumber);

            var message = new MailMessage
            {
                From = new MailAddress("noreply@newbalance.com"), 
                IsBodyHtml = true, 
                Subject = string.Concat("Cancelled - ", orderNumber)
            };

            message.To.Add(new MailAddress(distribution.DistributionList));
            
            if (distribution.AdministrationSiteLink == string.Empty)    
            {
                message.Body = "<p>Order Number " + orderNumber + " was cancelled.</p>Order Number: " + orderNumber + "<br />";    
            }
            else
            {
                message.Body = "<p>Order Number <a href=\"" + distribution.AdministrationSiteLink + cancellation.OrderNumber + "\">" + orderNumber + "</a> was cancelled.</p>";
            }

            message.Body += "</table>";

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }
    }
}
