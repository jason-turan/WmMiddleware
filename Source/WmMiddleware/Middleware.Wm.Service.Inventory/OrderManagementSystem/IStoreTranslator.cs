using System;

namespace Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem
{
    [Obsolete("Use IWebsiteRepository")]
    public interface IStoreIdTranslator
    {
        string TranslateStoreIdToSiteId(string storeId);
        string TranslateSiteIdToStoreId(string siteId);
    }
}
