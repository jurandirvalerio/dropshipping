using System;
using System.Web.Mvc;
using AutoMapper;
using Loja.Areas.Administracao.Models.Fornecedores;
using Loja.Infrastructure.Authentication;
using Servicos.Contratos;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class FornecedoresController : Controller
	{
		private readonly IFornecedorService _fornecedorService;

		public FornecedoresController(IFornecedorService fornecedorService)
		{
			_fornecedorService = fornecedorService;
		}

		public ActionResult Index()
        {
	        ViewBag.Title = "Fornecedores";
			return View();
        }

	    public ActionResult Incluir()
	    {
		    return View();
	    }

	    public ActionResult Alterar(int codigo)
	    {
		    return View(Mapper.Map<FornecedorViewModel>(_fornecedorService.Obter(codigo)));
	    }

		[HttpPost]
		public JsonResult Listar()
		{
			return Json(_fornecedorService.Listar());
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