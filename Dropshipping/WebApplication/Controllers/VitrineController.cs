using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Loja.Models.Produtos;
using Servicos.Contratos;

namespace Loja.Controllers
{
    public class VitrineController : Controller
    {
	    private readonly IProdutoService _produtoService;

	    public VitrineController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

	    // GET: Loja/Home
        public ActionResult Index()
        {
	        return View(new VitrineViewModel
	        {
		        Produtos = Mapper.Map<List<ProdutoDTO>, List<ProdutoViewModel>>(_produtoService.ListarProdutosEmDestaque())
	        });
        }
    }
}