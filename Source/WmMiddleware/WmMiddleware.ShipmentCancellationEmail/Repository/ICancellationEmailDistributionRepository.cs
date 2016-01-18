using WmMiddleware.ShipmentCancellationEmail.Models;

namespace WmMiddleware.ShipmentCancellationEmail.Repository
{
    public interface ICancellationEmailDistributionRepository
    {
        ShipmentCancellationEmailDistribution GetShipmentCancellationEmailDistribution(string company);
    }
}
