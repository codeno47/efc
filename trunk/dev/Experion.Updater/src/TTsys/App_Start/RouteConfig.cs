using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TTsys
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "TTLog", action = "LoadDetails", id = UrlParameter.Optional }
                    //defaults: new { controller = "TTracker", action = "LoadSearchScreen", id = UrlParameter.Optional }
                     defaults: new { controller = "TTLog", action = "LandingPage", id = UrlParameter.Optional }
            );
        }
    }
}