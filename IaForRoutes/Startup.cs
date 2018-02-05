using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IaForRoutes.Startup))]
namespace IaForRoutes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
