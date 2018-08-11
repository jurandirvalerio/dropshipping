using System.Web.Mvc;
using Loja.Infrastructure.Authentication;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
    public class ProdutosController : Controller
    {
		public ActionResult Index()
		{
            return View();
		}

	    public ActionResult Listar()
	    {
		    ViewBag.Title = "Produtos";
		    return View();
	    }
	}
}