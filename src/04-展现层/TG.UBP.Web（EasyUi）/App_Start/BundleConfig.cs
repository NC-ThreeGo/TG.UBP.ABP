using System.Web.Optimization;

namespace TG.UBP.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css")
                    .Include("~/Scripts/sweetalert/sweet-alert.css")
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/Scripts/json2.min.js",

                        "~/Scripts/jquery-2.1.4.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/main.css")
                );

            //~/Bundles/js
            bundles.Add(
                new ScriptBundle("~/Bundles/js")
                    .Include("~/js/main.js")
                );

            #region Ymnets的Bundle
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                       "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Scripts/home.js"));
            bundles.Add(new ScriptBundle("~/bundles/account").Include(
                       "~/Scripts/Account.js"));
            //easyui
            bundles.Add(new StyleBundle("~/Content/themes/coolblacklight/css").Include("~/Content/themes/skin-coolblacklight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/coolblack/css").Include("~/Content/themes/skin-coolblack.css"));
            bundles.Add(new StyleBundle("~/Content/themes/redlight/css").Include("~/Content/themes/skin-redlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/red/css").Include("~/Content/themes/skin-red.css"));
            bundles.Add(new StyleBundle("~/Content/themes/yellowlight/css").Include("~/Content/themes/skin-yellowlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/yellow/css").Include("~/Content/themes/skin-yellow.css"));
            bundles.Add(new StyleBundle("~/Content/themes/purplelight/css").Include("~/Content/themes/skin-purplelight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/purple/css").Include("~/Content/themes/skin-purple.css"));
            bundles.Add(new StyleBundle("~/Content/themes/greenlight/css").Include("~/Content/themes/skin-greenlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/green/css").Include("~/Content/themes/skin-green.css"));
            bundles.Add(new StyleBundle("~/Content/themes/bluelight/css").Include("~/Content/themes/skin-bluelight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/blue/css").Include("~/Content/themes/skin-blue.css"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryfrom").Include(
                        "~/Scripts/jquery.form.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyui/easyuiplus").Include(
                        "~/Scripts/easyui/jquery.easyui.plus.js"));
            bundles.Add(new ScriptBundle("~/bundles/easyui/datagridfilter").Include(
                       "~/Scripts/easyui/datagrid-filter.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.unobtrusive.plus.js"));

            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            #endregion
        }
    }
}