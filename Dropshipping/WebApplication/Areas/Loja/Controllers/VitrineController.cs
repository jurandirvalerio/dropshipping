using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Entidades;
using Servicos.Contratos;
using WebApplication.Areas.Loja.Models;

namespace WebApplication.Areas.Loja.Controllers
{
    public class VitrineController : Controller
    {
	    private IProdutoService _produtoService;

	    public VitrineController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

	    // GET: Loja/Home
        public ActionResult Index()
        {
	        ViewBag.Title = "Chef`s - Tudo para sua cozinha";
	        var produtoSet = Mapper.Map<List<Produto>, List<ProdutoViewModel>>(_produtoService.ListarProdutosEmDestaque());
	        var x = new VitrineViewModel { Produtos = produtoSet };
			return View(x);
        }
    }
}