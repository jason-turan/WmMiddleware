using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem
{
    public interface IStoreIdTranslator
    {
        string TranslateStoreIdToSiteId(string storeId);
        string TranslateSiteIdToStoreId(string siteId);
    }
}
