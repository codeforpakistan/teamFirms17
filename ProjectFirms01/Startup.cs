using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectFirms01.Startup))]
namespace ProjectFirms01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
