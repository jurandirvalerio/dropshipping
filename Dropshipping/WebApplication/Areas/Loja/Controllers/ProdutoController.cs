using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}