using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BollywoodBoxOffice.Web.Startup))]
namespace BollywoodBoxOffice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
