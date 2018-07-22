using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Areas.Loja.Controllers
{
    public class HomeController : Controller
    {
        // GET: Loja/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}