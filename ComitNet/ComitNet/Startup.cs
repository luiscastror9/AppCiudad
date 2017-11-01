using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComitNet.Startup))]
namespace ComitNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
