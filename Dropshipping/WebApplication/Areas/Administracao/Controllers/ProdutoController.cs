using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Loja.Areas.Administracao.Models.Produto;
using Loja.Infrastructure.Authentication;
using Servicos.Contratos;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class ProdutoController : Controller
	{
		private readonly IProdutoService _produtoService;

		public ProdutoController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}

	    public ActionResult Listar()
	    {
			return View();
	    }

		[HttpPost]
		public JsonResult ListarProdutos()
		{
			return Json(_produtoService.ListarTodosProdutos());
		}

		[HttpPost]
	    public JsonResult Incluir(ProdutoFornecedorDTO produtoFornecedorDto)
	    {
		    _produtoService.Incluir(produtoFornecedorDto);
		    return Json(true);
	    }

		public ActionResult Alterar(int codigo)
		{
			return View(Mapper.Map<ProdutoCadastroDTO, ProdutoViewModel>(_produtoService.ObterParaCadastro(codigo)));
		}

		[HttpPost]
		public ActionResult Alterar(ProdutoCadastroDTO produtoFornecedorDto)
		{
			_produtoService.Alterar(produtoFornecedorDto);
			return RedirectToAction("Listar", "Produto", new {area = "Administracao"});
		}
	}
}