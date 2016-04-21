using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class DatabaseWebsiteRepository : IWebsiteRepository
    {
        public Website GetByStoreId(string storeId)
        {
            switch(storeId)
            {
                case "2100":
                    return new Website { SiteId = "JNBO" };
                case "2000":
                    return new Website { SiteId = "NBUS" };
                case "2200":
                    return new Website { SiteId = "PF" };
                case "3500":
                    return new Website { SiteId = "NBCA" };
                default:
                    return null;
            }
        }
    }
}