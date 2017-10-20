using System.Web.Mvc;
using System.Web.Routing;

namespace Cars.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
