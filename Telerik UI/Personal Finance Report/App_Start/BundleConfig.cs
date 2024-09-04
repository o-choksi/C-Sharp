// App_Start/BundleConfig.cs

using System.Web;
using System.Web.Optimization;

namespace PersonalFinanceReport
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle for custom JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/financeReport.js",
                        "~/Scripts/kendo.all.min.js"));

            // Bundle for custom CSS files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/kendo.common.min.css",
                      "~/Content/kendo.default.min.css"));

            // Enable bundling and minification in debug mode for testing
            BundleTable.EnableOptimizations = true;
        }
    }
}
