using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FARAHAT.Startup))]
namespace FARAHAT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
