using Microsoft.AspNet.Identity;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Authentication
{
	public class LojaUserManager : UserManager<Usuario>
	{
		public LojaUserManager(IUserStore<Usuario> store) : base(store)
		{
		}
	}
}