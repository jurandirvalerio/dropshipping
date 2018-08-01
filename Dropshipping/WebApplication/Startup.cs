using Microsoft.Owin;
using Owin;
using WebApplication.Infrastructure.Authentication;

[assembly: OwinStartupAttribute(typeof(WebApplication.Startup))]
namespace WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
	        app.CreatePerOwinContext(AuthenticationContext.Create);
	        app.CreatePerOwinContext<UsuarioManager>(UsuarioManager.Create);
        }
    }
}