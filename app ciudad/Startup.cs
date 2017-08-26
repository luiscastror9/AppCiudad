using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(app_ciudad.Startup))]
namespace app_ciudad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
