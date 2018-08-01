using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
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
	        app.CreatePerOwinContext<LoginManager>(LoginManager.Create);
	        app.CreatePerOwinContext<RoleManager>(RoleManager.Create);

			app.UseCookieAuthentication(new CookieAuthenticationOptions
	        {
		        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
		        LoginPath = new PathString("/Login"),
		        CookieName = "LojaDropshipping",
		        CookiePath = "/"
	        });
		}
    }
}