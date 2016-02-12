namespace Middleware.Wm.Shipping
{
    public interface ICarrierReadRepository
    {
        string GetOmsShipMethod(string code, bool useThirdPartyBilling = false);
        string GetCode(string omsShipMethod, bool useThirdPartyBilling = false);
    }
}
