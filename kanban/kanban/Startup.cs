using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kanban.Startup))]
namespace kanban
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
