using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //TUTAJ ZMIENIŁEM
                //W kontrolerze podałem żeby otwierało się z domyślnego kontrolera "Klienci" 
                defaults: new { controller = "Klienci", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
