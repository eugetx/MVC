using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMasterDetailsEntry.Startup))]
namespace MVCMasterDetailsEntry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
