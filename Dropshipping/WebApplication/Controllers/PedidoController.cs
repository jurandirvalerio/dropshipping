using System.Web.Mvc;
using Loja.Models.Pedido;

namespace Loja.Controllers
{
	[Authorize]
    public class PedidoController : Controller
    {
		public ActionResult Index()
        {
            return View();
        }

	    [HttpPost]
	    public JsonResult Confirmar(PedidoViewModel pedidoViewModel)
	    {
		    return Json(true);
	    }
    }
}