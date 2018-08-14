using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
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
	    public JsonResult Incluir(FornecedorViewModel fornecedorViewModel)
	    {
			throw new NotImplementedException();
	    }

	    [HttpPost]
		public JsonResult Alterar(FornecedorViewModel fornecedorViewModel)
	    {
		    throw new NotImplementedException();
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