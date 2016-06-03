using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspxPages.Startup))]
namespace AspxPages
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
