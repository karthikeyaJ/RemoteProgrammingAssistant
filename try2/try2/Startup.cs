using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(try2.Startup))]
namespace try2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
