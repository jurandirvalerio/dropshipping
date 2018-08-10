using System;
using Loja;
using Loja.Infrastructure.Authentication;
using Loja.Models.Login;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Loja
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
	        app.CreatePerOwinContext(AuthenticationDbContext.Create);
	        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
	        app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

	        app.UseCookieAuthentication(new CookieAuthenticationOptions
	        {
		        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
		        LoginPath = new PathString("/Login/Login"),
		        Provider = new CookieAuthenticationProvider
		        {
			        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
				        validateInterval: TimeSpan.FromMinutes(30),
				        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
		        }
	        });
		}
    }
}