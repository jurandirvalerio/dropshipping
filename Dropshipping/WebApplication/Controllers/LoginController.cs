using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApplication.Infrastructure.Authentication;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
		public async Task<ActionResult> Index()
		{
			var userManager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();

			var user = await userManager.FindAsync("jurandirvalerio@gmail.com", "123Trocar@@");

			var appAsign = HttpContext.GetOwinContext().Get<LoginManager>();

			appAsign.SignIn(user, true, true);

			return View();
		}

	    [Authorize]
	    public ActionResult Autorizado()
	    {
		    var cookie = HttpContext.Request.Cookies["LojaDropshipping"];

		    IPrincipal user = HttpContext.User;

		    return View();
	    }

	    public async Task<ActionResult> Role()
	    {
		    var appRole = HttpContext.GetOwinContext().Get<RoleManager>();

		    var role = new IdentityRole("vendedor");

		    await appRole.CreateAsync(role);

		    var userManager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();

		    var user = await userManager.FindAsync("jurandirvalerio@gmail.com", "123Trocar@@");

		    await userManager.AddToRoleAsync(user.Id, role.Name);

		    return View();
	    }

	    [Authorize(Roles = "Devimedia")]
	    public ActionResult TestarRole()
	    {
		    return View();
	    }
	}
}