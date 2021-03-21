using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppReporteriayQuejas.Startup))]
namespace WebAppReporteriayQuejas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
