using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Authentication
{
	public class UsuarioManager : UserManager<Usuario>
	{
		public UsuarioManager(IUserStore<Usuario> store) : base(store)
		{

		}

		public static UsuarioManager Create(IdentityFactoryOptions<UsuarioManager> options, IOwinContext context)
		{
			var appcontext = context.Get<AuthenticationContext>();
			return new UsuarioManager(new UserStore<Usuario>(appcontext));
		}
	}
}