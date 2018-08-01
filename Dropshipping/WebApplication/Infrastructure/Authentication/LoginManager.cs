using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Authentication
{
	public class LoginManager : SignInManager<Usuario, string>
	{
		public LoginManager(UsuarioManager usuarioManager, IAuthenticationManager authenticationManager) : base(usuarioManager, authenticationManager)
		{

		}

		public static LoginManager Create(IdentityFactoryOptions<LoginManager> option, IOwinContext context)
		{
			var manager = context.GetUserManager<UsuarioManager>();
			return new LoginManager(manager, context.Authentication);
		}
	}
}