using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Serialization;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();
            
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*","*", "GET, POST, OPTIONS"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
