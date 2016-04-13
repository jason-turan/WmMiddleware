using System.Web;
using System.Web.Mvc;

namespace NB.DTC.Aptos.InventoryService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
