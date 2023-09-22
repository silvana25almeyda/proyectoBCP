using System.Web.Http;
using WebActivatorEx;
using BCP.Optimizacion.Presentation.Rest;
using Swashbuckle.Application;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BCP.Optimizacion.Presentation.Rest
{
    public class SwaggerConfig
    {
        private static string GetXmlCommentsPath()
        {
            return Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "bin", "BCP.Optimizacion.Presentation.Rest.xml");
        }

        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "BCP.Optimizacion.Presentation.Rest").
                        Description("Api Rest de Ventas BCP")
                        .Contact(x => x.Name("Silvana Almeyda"));
                        c.PrettyPrint();
                        c.ApiKey("Authorization")
                            .Description("Ingresa el Token JWT aquí.")
                            .Name("Bearer")
                            .In("header");

                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Api Rest Ventas BCP");
                        c.EnableApiKeySupport("Authorization", "header");
                    });
        }
    }
}
