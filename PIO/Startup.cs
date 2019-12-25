using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PIO.Startup))]
namespace PIO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
