using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzarRoz.Startup))]
namespace AzarRoz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
