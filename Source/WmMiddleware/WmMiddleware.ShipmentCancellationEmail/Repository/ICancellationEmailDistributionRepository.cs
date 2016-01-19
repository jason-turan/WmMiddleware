using System.Collections.Generic;
using WmMiddleware.ShipmentCancellationEmail.Models;

namespace WmMiddleware.ShipmentCancellationEmail.Repository
{
    public interface ICancellationEmailDistributionRepository
    {
        ShipmentCancellationEmailDistribution GetShipmentCancellationEmailDistribution(string company);

        IEnumerable<Models.ShipmentCancellationEmail> GetCancellations();

        string GetCompanyFromOrderNumber(string orderNumber);
    }
}
