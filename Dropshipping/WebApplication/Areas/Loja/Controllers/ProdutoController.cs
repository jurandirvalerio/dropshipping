using System.Web.Mvc;

namespace WebApplication.Areas.Loja.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Loja/Produtos
        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult Detalhe(int id)
	    {
		    return View();
	    }
    }
}