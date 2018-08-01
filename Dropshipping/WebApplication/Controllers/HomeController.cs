using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WebApplication.Infrastructure.Authentication;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
		// GET: Home
	    public async Task<ActionResult> Index()
	    {
		    // Contexto Global
		    var contexto = HttpContext.GetOwinContext();

		    // UserManager disponibilizado no contexto
		    var manager = contexto.GetUserManager<UsuarioManager>();

		    // Usuario - classe filha de IdentityUser
		    var usuario = new Usuario()
		    {
			    UserName = "jurandirvalerio@gmail.com",
			    Nome = "Jurandir",
			    Sobrenome = "Valerio",
			    Email = "jurandirvalerio@gmail.com"
			};

		    // Método disponibilizado pela classe UserManager
		    await manager.CreateAsync(usuario, "123Trocar@@");

		    return View();
	    }
	}
}