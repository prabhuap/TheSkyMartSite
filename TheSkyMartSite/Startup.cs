using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheSkyMartSite.Startup))]
namespace TheSkyMartSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
