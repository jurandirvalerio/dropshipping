using Loja.Models.Login;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Loja.Infrastructure.Authentication
{
	public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
	{
		public AuthenticationDbContext() : base("LojaDbContext", throwIfV1Schema: false)
		{
		}

		public static AuthenticationDbContext Create()
		{
			return new AuthenticationDbContext();
		}
	}
}