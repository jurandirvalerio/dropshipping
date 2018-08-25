using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Loja.Models.Produtos;
using Servicos.Contratos;

namespace Loja.Controllers
{
    public class CarrinhoController : Controller
    {
	    private readonly IProdutoService _produtoService;

	    public CarrinhoController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

	    public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
	    public JsonResult ObterProdutosCarrinho(int[] codigoProdutoSet)
		{
			return Json(Mapper.Map<List<ProdutoDTO>, List<ProdutoViewModel>>(
				_produtoService.ListarProdutosParaVitrine(codigoProdutoSet)));
		}
    }
}