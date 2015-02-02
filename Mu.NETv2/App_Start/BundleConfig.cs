﻿using System.Web;
using System.Web.Optimization;

namespace Mu.NETv2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
           
            bundles.Add(new ScriptBundle("~/bundles/orizon").Include(
                "~/Content/themes/orizon/javascript/getTweet.js",
                "~/Content/themes/orizon/javascript/jquery.bxSlider.min.js",
                "~/Content/themes/orizon/javascript/jquery.carouFredSel-6.1.0.js",
                "~/Content/themes/orizon/javascript/jquery.cslider.js",
                "~/Content/themes/orizon/javascript/jquery.easing.1.3.js",
                "~/Content/themes/orizon/javascript/jquery.fancybox.js",
                "~/Content/themes/orizon/javascript/jquery.validationEngine.js",
                "~/Content/themes/orizon/javascript/jquery.validationEngine-en.js",
                "~/Content/themes/orizon/javascript/modernizr.custom.28468.js"));
            bundles.Add(new StyleBundle("~/Content/themes/orizon/stylesheets/topcss").Include(
                        "~/Content/themes/orizon/stylesheets/main.css",
                        "~/Content/themes/orizon/stylesheets/bxSlider.css",
                        "~/Content/themes/orizon/stylesheets/devices.css",
                        //"~/Content/themes/orizon/stylesheets/ie.css",
                        //"~/Content/themes/orizon/stylesheets/jquery.fancybox.css?v=2.1.2",
                        "~/Content/themes/orizon/stylesheets/paralax_slider.css",
                        "~/Content/themes/orizon/stylesheets/post.css",
                        "~/Content/themes/orizon/stylesheets/validationEngine.jquery.css"));
        }
    }
}