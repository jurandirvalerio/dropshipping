using System.Web.Mvc;

namespace Loja.Controllers
{
	[Authorize]
    public class PedidoController : Controller
    {
		public ActionResult Index()
        {
            return View();
        }
    }
}