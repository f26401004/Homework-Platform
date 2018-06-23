using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeworkPlatform.Startup))]
namespace HomeworkPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
