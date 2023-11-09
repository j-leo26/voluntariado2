using System.Web.Mvc;
using System.Web.Routing;

namespace voluntariado2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Users",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "offers",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Offer", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Interfaces",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Interfaces", action = "UserRegisterOferror", id = UrlParameter.Optional }
            );

        }
    }
}
