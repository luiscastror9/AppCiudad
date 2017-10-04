using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lamarque_web.Startup))]
namespace Lamarque_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
