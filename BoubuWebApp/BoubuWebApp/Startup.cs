using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BoubuWebApp.Startup))]

namespace BoubuWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // クロスドメイン対応
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}