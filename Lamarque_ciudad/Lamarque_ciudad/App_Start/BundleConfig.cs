using System.Web;
using System.Web.Optimization;

namespace Lamarque_ciudad
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

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style-nav.css"));

            bundles.Add(new ScriptBundle("~/bundles/headerJS").Include(
                        "~/Scripts/External/jquery.min.js",
                        "~/Scripts/External/bootstrap.min.js",
                        "~/Scripts/ckeditor/ckeditor.js",
                        "~/Scripts/ckeditor/samples/js/sample.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/footer").Include(
                      "~/Scripts/External/jquery.min.js",
                      "~/Scripts/External/bootstrap.min.js",
                      "~/Scripts/External/bootstrap-datepicker.js",
                      "~/Scripts/External/bootstrap-datetimepicker.min.js",
                      "~/Scripts/Custom/Shared/Layout.js"
                      ));
        }
    }
}
