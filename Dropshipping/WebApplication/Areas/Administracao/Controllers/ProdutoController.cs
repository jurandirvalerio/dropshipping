using System.Web.Mvc;
using Loja.Infrastructure.Authentication;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
    public class ProdutoController : Controller
    {
		public ActionResult Index()
		{
            return View();
		}

	    public ActionResult Listar()
	    {
		    
		    return View();
	    }
	}
}