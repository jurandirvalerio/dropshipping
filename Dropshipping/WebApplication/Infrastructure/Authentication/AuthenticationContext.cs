using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Authentication
{
	public class AuthenticationContext : IdentityDbContext<Usuario>
	{
		public AuthenticationContext() : base("LojaDbContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public static AuthenticationContext Create()
		{
			return new AuthenticationContext();
		}
	}
}