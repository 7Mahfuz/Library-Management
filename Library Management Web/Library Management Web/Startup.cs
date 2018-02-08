using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library_Management_Web.Startup))]
namespace Library_Management_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
