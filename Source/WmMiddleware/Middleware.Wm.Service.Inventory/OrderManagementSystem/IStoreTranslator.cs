using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem
{
    [Obsolete("Use IWebsiteRepository")]
    public interface IStoreIdTranslator
    {
        string TranslateStoreIdToSiteId(string storeId);
        string TranslateSiteIdToStoreId(string siteId);
    }
}
