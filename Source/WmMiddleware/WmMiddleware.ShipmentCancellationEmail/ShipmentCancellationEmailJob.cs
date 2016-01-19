using System.Linq;
using System.Net.Mail;
using Middleware.Jobs;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.ShipmentCancellationEmail.Repository;

namespace WmMiddleware.ShipmentCancellationEmail
{
    public class ShipmentCancellationEmailJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IConfigurationManager _configurationManager;
        private readonly ICancellationEmailDistributionRepository _cancellationEmailDistributionRepository;

        public ShipmentCancellationEmailJob(ILog log, 
                                            IShipmentRepository shipmentRepository, 
                                            IConfigurationManager configurationManager,
                                            ICancellationEmailDistributionRepository cancellationEmailDistributionRepository)
        {
            _log = log;
            _shipmentRepository = shipmentRepository;
            _configurationManager = configurationManager;
            _cancellationEmailDistributionRepository = cancellationEmailDistributionRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var cancellations = _shipmentRepository.GetCancellations().ToList();

            if (!cancellations.Any())
            {
                _log.Info("No shipment line item cancellations to process");
            }
            else
            {
             _log.Info("Now processing " + cancellations.Count() + " line item shipment cancellations");   
            }

            foreach (var manhattanShipmentLineItem in cancellations)
            {
                var distribution = _cancellationEmailDistributionRepository.GetShipmentCancellationEmailDistribution(manhattanShipmentLineItem.OrderedCompany);
                SendEmail(distribution.DistributionList);
            }
        }

        private void SendEmail(string distributionList)
        {            
            var smptServer =
                _configurationManager.GetKey<string>(ConfigurationKey.AlertSmptServer);
            
            var message =
                new MailMessage("noreply@newbalance.com",
                                distributionList,
                                "WmMiddleware Failure",
                                "You are notified")
                {
                    Priority = MailPriority.High,
                    IsBodyHtml = true
                };

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }

    }
}
