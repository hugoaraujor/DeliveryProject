using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Adomicilio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
       
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //hugo araujo r
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "Registro",
             url: "Registro",
             defaults: new { controller = "Registro", action = "Index" }
         );
            // routes.MapRoute(
            //    name: "gruposmenu",
            //    url: "{controller}/{idempresa}/{id}/{action}",
            //    defaults: new { controller = "gruposmenus", action = "Index", idempresa = UrlParameter.Optional, id = UrlParameter.Optional }
            //);

        }
    }
}
