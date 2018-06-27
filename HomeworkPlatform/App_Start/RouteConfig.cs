using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeworkPlatform
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Home router
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/",
                defaults: new { controller = "Home", action = "Index" }
            );
            // Topic router
            routes.MapRoute(
                name: "Topic",
                url: "Topic/{action}/{id}/",
                defaults: new { controller = "Topic", action = "Index", id = UrlParameter.Optional}
            );

            // Account router
            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Login" }
            );
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
        }
    }
}
