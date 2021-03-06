﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _2018_SG_MVC_BTPROJECT.SG_UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdminLogin", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "2018_SG_MVC_BTPROJECT.SG_UI.Controllers" }
            );


          

        }
    }
}
