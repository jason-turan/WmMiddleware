using System.Web;
using System.Web.Optimization;

namespace Middleware.Scheduler.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // knockout data binding
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-{version}.js","~/Scripts/knockout.*"));
            // jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            // moment datetime library
            bundles.Add(new ScriptBundle("~/bundles/moment").Include("~/Scripts/moment.js"));
            // bootstrap styling
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css"));
            // modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            // modernizr
            bundles.Add(new ScriptBundle("~/bundles/json").Include("~/Scripts/json*"));
        }
    }
}