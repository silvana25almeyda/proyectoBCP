using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;

namespace BCP.Optimizacion.Presentation.Rest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterNullEmptyValue(config);
            RegisterCulture();

            // Web API configuration and services
            var politicasPeticionCors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(politicasPeticionCors);
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterCulture()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                    Culture = CultureInfo.GetCultureInfo("es-PE")
                };
        }

        public static void DisabledBehaviors(HttpConfiguration current)
        {
            var formatter = current.Formatters.OfType<JsonMediaTypeFormatter>().First();

            formatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            formatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            current.Formatters.Remove(current.Formatters.XmlFormatter);
        }

        public static void RegisterNullEmptyValue(HttpConfiguration config)
        {
            DisabledBehaviors(config);
        }
    }
}
