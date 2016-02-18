using System.Collections.Generic;
using Middleware.Wm.ShipmentCancellationEmail.Models;

namespace Middleware.Wm.ShipmentCancellationEmail.Repository
{
    public interface ICancellationEmailDistributionRepository
    {
        ShipmentCancellationEmailDistribution GetShipmentCancellationEmailDistribution(string company);

        IEnumerable<Middleware.Wm.ShipmentCancellationEmail.Models.ShipmentCancellationEmail> GetShipmentEmailCancellations();

        string GetCompanyFromOrderNumber(string orderNumber);
    }
}
