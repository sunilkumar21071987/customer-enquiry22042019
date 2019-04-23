using System.Web.Mvc;
using System.Web.Routing;

namespace enquiryDemo.api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional },
            new string[] { "enquiryDemo.api.Controllers" }
            );
        }
    }
}

