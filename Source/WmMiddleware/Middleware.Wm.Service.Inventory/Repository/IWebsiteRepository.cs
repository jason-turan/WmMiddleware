using Middleware.Wm.Service.Inventory.Models;
namespace Middleware.Wm.Service.Inventory.Repository
{
    public interface IWebsiteRepository
    {
        Website GetByStore(Store store);
    }
}
