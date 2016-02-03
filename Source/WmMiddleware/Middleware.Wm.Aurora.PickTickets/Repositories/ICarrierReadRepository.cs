namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public interface ICarrierReadRepository
    {
        string GetOmsShipMethod(string code);
    }
}
