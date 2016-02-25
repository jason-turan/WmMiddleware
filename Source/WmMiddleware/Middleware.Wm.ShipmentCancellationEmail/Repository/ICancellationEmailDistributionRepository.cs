using System.Collections.Generic;
using Middleware.Wm.ShipmentCancellationEmail.Models;

namespace Middleware.Wm.ShipmentCancellationEmail.Repository
{
    public interface ICancellationEmailDistributionRepository
    {
        ShipmentCancellationEmailDistribution GetShipmentCancellationEmailDistribution(string company);
        IEnumerable<Models.ShipmentCancellationEmail> GetShipmentEmailCancellations();
        void SetAsProcessed(IEnumerable<Models.ShipmentCancellationEmail> emails);
        string GetCompanyFromOrderNumber(string orderNumber);
    }
}
