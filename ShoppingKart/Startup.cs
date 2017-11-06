using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingKart.Startup))]
namespace ShoppingKart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
