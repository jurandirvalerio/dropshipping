using System;
using System.Web.Mvc;
using Loja.Areas.Administracao.Models.Fornecedores;
using Loja.Infrastructure.Authentication;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class FornecedoresController : Controller
    {
		public ActionResult Listar()
        {
	        ViewBag.Title = "Fornecedores";
			return View();
        }

	    public ActionResult Incluir()
	    {
		    return View();
	    }

	    public ActionResult Alterar()
	    {
		    return View();
	    }

		[HttpPost]
	    public JsonResult Incluir(FornecedorViewModel fornecedorViewModel)
	    {
			throw new NotImplementedException();
	    }

	    [HttpPost]
		public JsonResult Alterar(FornecedorViewModel fornecedorViewModel)
	    {
		    throw new NotImplementedException();
		}
	}
}