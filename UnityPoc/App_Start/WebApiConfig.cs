using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace UnityPoc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var exceptionLogger = config.DependencyResolver.GetService(typeof(IExceptionLogger));
            config.Services.Replace(typeof(IExceptionLogger), exceptionLogger);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
