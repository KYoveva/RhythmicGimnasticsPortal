using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RhythmicGymnasticsPortal.Web.Startup))]
namespace RhythmicGymnasticsPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
