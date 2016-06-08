using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AFEWellBook.Startup))]
namespace AFEWellBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
