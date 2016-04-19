using Middleware.Wm.Service.Inventory.Filters;
using System.Web.Http.Filters;

namespace Middleware.Wm.Service.Inventory
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new ValidateModelAttribute());
        }
    }
}
