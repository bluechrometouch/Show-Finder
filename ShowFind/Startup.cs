using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowFind.Startup))]
namespace ShowFind
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
