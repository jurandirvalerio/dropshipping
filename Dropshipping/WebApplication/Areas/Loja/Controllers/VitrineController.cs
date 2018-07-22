using System.Web.Mvc;

namespace WebApplication.Areas.Loja.Controllers
{
    public class VitrineController : Controller
    {
        // GET: Loja/Home
        public ActionResult Index()
        {
	        ViewBag.Title = "Chef`s - Tudo para sua cozinha";
	        return View();
        }
    }
}