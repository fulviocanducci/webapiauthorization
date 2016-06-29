using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
//https://msdn.microsoft.com/pt-br/library/dn376307.aspx
//http://weblogs.asp.net/andrebaltieri/implementando-bearer-autentication-com-webapi-e-owin
//http://www.leonardohofling.com/blog/web-api-adicionando-autenticacao-oauth/
//http://waldyrfelix.com.br/2012/11/01/asp-net-webapi-basic-authentication/
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
