namespace Middleware.Wm.Shipping
{
    public interface ICarrierReadRepository
    {
        string GetOmsShipMethod(string code);
        string GetCode(string omsShipMethod);
    }
}
