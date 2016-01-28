namespace WmMiddleware.Picking.Repositories
{
    public interface ICarrierReadRepository
    {
        string GetOmsShipMethod(string code);
        string GetCode(string omsShipMethod);
    }
}
