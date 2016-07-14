using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedOffice.Startup))]
namespace SharedOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
