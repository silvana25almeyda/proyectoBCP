using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BCP.Optimizacion.Presentation.Rest.Startup))]

namespace BCP.Optimizacion.Presentation.Rest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
            HttpContext.Current.Server.ScriptTimeout = 3600;
        }
    }
}
