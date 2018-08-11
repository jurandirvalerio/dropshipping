using System;
using Loja.Models.Login;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Loja.Infrastructure.Authentication
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store)
			: base(store)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<AuthenticationDbContext>()));
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<AuthenticationDbContext>()));

			const string roleAdmin = "Admin";

			if (!roleManager.RoleExists(roleAdmin))
			{
				roleManager.Create(new IdentityRole { Name = roleAdmin });
				var user = new ApplicationUser { UserName = "admin@dropshipping.com", Email = "admin@dropshipping.com" };
				var identityResult = userManager.Create(user, "123456");

				if (identityResult.Succeeded)
				{
					userManager.AddToRole(user.Id, roleAdmin);
				}
			}

			// Configure validation logic for usernames
			userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			userManager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false
			};

			// Configure user lockout defaults
			userManager.UserLockoutEnabledByDefault = true;
			userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			userManager.MaxFailedAccessAttemptsBeforeLockout = 5;

			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			}

			return userManager;
		}
	}
}