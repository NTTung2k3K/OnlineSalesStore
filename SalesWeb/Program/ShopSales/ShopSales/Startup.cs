using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopSales.Startup))]
namespace ShopSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
