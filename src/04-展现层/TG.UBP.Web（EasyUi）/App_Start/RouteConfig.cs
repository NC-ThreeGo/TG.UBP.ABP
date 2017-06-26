using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TG.UBP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ASP.NET Web API Route Config
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //Ymnets加了多语言的Route
            routes.MapRoute(
                "Globalization", // 路由名称
                "{lang}/{controller}/{action}/{id}", // 带有参数的 URL
                new { lang = "zh", controller = "Home", action = "Index", id = UrlParameter.Optional }, // 参数默认值
                new { lang = "^[a-zA-Z]{2}-[a-zA-Z]{2}?$" }    //参数约束
                 , namespaces: new string[] { "TG.UBP.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                , namespaces : new string[] { "TG.UBP.Web.Controllers" }
            );
        }
    }
}
