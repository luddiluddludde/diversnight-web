using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diversnight.Web.Startup))]
namespace Diversnight.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
