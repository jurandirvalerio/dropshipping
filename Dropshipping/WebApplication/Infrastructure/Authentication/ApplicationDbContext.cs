using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Authentication
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext() : base("LojaDbContext", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}