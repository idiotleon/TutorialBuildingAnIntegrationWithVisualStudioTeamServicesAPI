using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorialVSTSAPI1.Startup))]
namespace TutorialVSTSAPI1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
