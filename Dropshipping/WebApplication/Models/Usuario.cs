using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication.Models
{
	public class Usuario : IdentityUser
	{
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
	}
}