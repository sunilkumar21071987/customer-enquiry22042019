using System.Web.Http;
using System.Web.Http.Cors;

namespace enquiryDemo.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
