using System.Web;
using System.Web.Optimization;

namespace Example.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/js/base/library").Include(
                    "~/App/vendor/jquery-1.11.2.min.js",
                    "~/App/vendor/angularJs/angular.min.js",
                    "~/App/vendor/angularJs/angular-ui-router.js",
                    "~/App/vendor/bootstrap/js/bootstrap.min.js",
                    "~/App/vendor/bootstrap/js/ui-bootstrap-tpls-0.13.0.min.js",
                    "~/App/vendor/bootstrap-notify/bootstrap-notify.min.js"
                   ));
            //angularjs 项目文件
            bundles.Add(new ScriptBundle("~/js/angularjs/app").Include(
                    "~/app/scripts/services/*.js",
                    "~/app/scripts/controllers/*.js",
                    //"~/app/scripts/directives/*.js",
                    "~/app/scripts/filters/*.js",
                    "~/app/scripts/app.js"));
            //样式
            bundles.Add(new StyleBundle("~/js/base/style").Include(
                    "~/App/vendor/bootstrap/css/bootstrap.min.css",
                    "~/App/vendor/themify-icons/themify-icons.min.css",
                    "~/App/assets/css/styles.css",
                    "~/App/assets/css/plugins.css",
                    "~/App/assets/css/themes/theme-1.css"
                    ));
        }
    }
}
