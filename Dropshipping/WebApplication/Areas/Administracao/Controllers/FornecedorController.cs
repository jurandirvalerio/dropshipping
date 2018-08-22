using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Loja.Areas.Administracao.Models.Fornecedor;
using Loja.Infrastructure.Authentication;
using Servicos.Contratos;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class FornecedorController : Controller
	{
		private readonly IFornecedorService _fornecedorService;

		public FornecedorController(IFornecedorService fornecedorService)
		{
			_fornecedorService = fornecedorService;
		}

		public ActionResult Index()
        {
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
	    public ActionResult Incluir(FornecedorViewModel fornecedorViewModel)
	    {
		    _fornecedorService.Incluir(Mapper.Map<FornecedorDTO>(fornecedorViewModel));
		    return RedirectToAction("Index", "Fornecedor", new { area = "Administracao" });
		}

	    [HttpPost]
		public ActionResult Alterar(FornecedorViewModel fornecedorViewModel)
	    {
		    _fornecedorService.Alterar(Mapper.Map<FornecedorDTO>(fornecedorViewModel));
		    return RedirectToAction("Index", "Fornecedor", new { area = "Administracao" });

		}

		public ActionResult Produtos(int codigo)
		{
			ViewBag.Fornecedor = _fornecedorService.Obter(codigo).Nome;
			return View();
		}

		[HttpPost]
		public JsonResult ListarProdutos(int codigo)
		{
			return Json(_fornecedorService.ListarProdutos(codigo));
		}
	}
}