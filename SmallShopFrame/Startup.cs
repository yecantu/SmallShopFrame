using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmallShopFrame.Startup))]
namespace SmallShopFrame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
