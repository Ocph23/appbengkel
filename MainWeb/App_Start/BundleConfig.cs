using System.Web;
using System.Web.Optimization;

namespace MainWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/node_modules/mdbootstrap/js/bootstrap.js",
                     "~/node_modules/mdbootstrap/js/mdb.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/node_modules/mdbootstrap/css/bootstrap.css" ,
                     "~/node_modules/mdbootstrap/css/mdb.css" ,
                              "~/Content/site.css"));
        }
    }
}
