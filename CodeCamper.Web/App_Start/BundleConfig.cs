﻿using System.Web.Optimization;

namespace CodeCamper.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Force optimization to be on or off, regardless of web.config setting
            //BundleTable.EnableOptimizations = false;
       
            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            bundles.UseCdn = true;

            // All application JS files (except mocks")
            bundles.Add(new ScriptBundle("~/bundles/jsapplibs")
                // Include all files in the named directory that match "*.js";
                // Could include subdirs too by flipping the flag
                // but not doing so because the only subdir holds mocks
                // which we would exclude anyway in production.
                .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

                // the following equivalent file-pattern alternative 
                // could not consider subdirectories if we wanted those
                //.Include("~/Scripts/app/*.js")); 

            bundles.Add(new ScriptBundle("~/bundles/jsmocks")
                .IncludeDirectory("~/Scripts/app/mock", "*.js", searchSubdirectories: false));


            // Modernizr goes separate since its a shiv
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js")
                .Include("~/Scripts/lib/jquery-1.8.2.js"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                .Include(
                    "~/Scripts/lib/json2.min.js", // IE7 needs this

                    // jQuery plugins
                    "~/Scripts/lib/activity-indicator.js",
                    "~/Scripts/lib/jquery.mockjson.js",
                    "~/Scripts/lib/TrafficCop.js",
                    "~/Scripts/lib/infuser.js", // depends on TrafficCop

                    // Knockout and its plugins
                    "~/Scripts/lib/knockout-2.1.0.js",
                    "~/Scripts/lib/knockout.validation.js",
                    "~/Scripts/lib/koExternalTemplateEngine.js",

                    "~/Scripts/lib/underscore.min.js",
                    "~/Scripts/lib/moment.js",

                    "~/Scripts/lib/sammy.*",

                    "~/Scripts/lib/amplify.*",
                    
                    "~/Scripts/lib/toastr.js"
                    ));

            // 3rd Party CSS files
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/boilerplate-style.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/toastr-responsive.css"));

            // Custom LESS files
            var lessBundle = new Bundle("~/Content/Less")
                .Include("~/Content/styles.less");

            lessBundle.Transforms.Add(new LessTransform());
            lessBundle.Transforms.Add(new CssMinify());
            
            bundles.Add(lessBundle);
        }
    }
}