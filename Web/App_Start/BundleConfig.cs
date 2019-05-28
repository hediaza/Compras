using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.3.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery.all").Include(
            //    //"~/Scripts/jquery-1.12.3.min.js",
            //    "~/Scripts/kendo/2018.1.117/jquery.min.js",
            //    "~/Scripts/jquery.unobtrusive-ajax.min.js",
            //    "~/Scripts/jquery.validate.min.js",
            //    "~/Scripts/jquery.validate.unobtrusive.min.js"));

            var jqueryAllScriptBundle = new ScriptBundle("~/bundles/jquery.all").Include(
                "~/Scripts/kendo/2018.1.117/jquery.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
            );
            jqueryAllScriptBundle.Orderer = new PassthruBundleOrderer();
            bundles.Add(jqueryAllScriptBundle);

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                      "~/Scripts/plugins/pace/pace.min.js"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            // toastr notification 
            bundles.Add(new ScriptBundle("~/plugins/toastr").Include(
                      "~/Scripts/plugins/toastr/toastr.min.js"));

            // toastr notification styles
            bundles.Add(new StyleBundle("~/plugins/toastrStyles").Include(
                      "~/Content/plugins/toastr/toastr.min.css"));

            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/plugins/sweetAlertStyles").Include(
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));

        }
    }

    class PassthruBundleOrderer : IBundleOrderer {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files) {
            return files;
        }
    }
}
