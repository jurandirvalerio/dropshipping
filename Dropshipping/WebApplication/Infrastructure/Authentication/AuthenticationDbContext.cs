using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Models.Login;

namespace WebApplication.Infrastructure.Authentication
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