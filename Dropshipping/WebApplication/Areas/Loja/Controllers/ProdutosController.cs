using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Servicos.Contratos;
using WebApplication.Areas.Loja.Models;

namespace WebApplication.Areas.Loja.Controllers
{
    public class ProdutosController : Controller
    {
	    private readonly IProdutoService _produtoService;

	    public ProdutosController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

	    // GET: Loja/Produtos
        public ActionResult Index()
		{
			return View(Mapper.Map<List<ProdutoDTO>, List<ProdutoViewModel>>(_produtoService.ListarTodosProdutos()));
        }

	    public ActionResult Detalhe(int id)
	    {
			return View(Mapper.Map<ProdutoDTO, ProdutoViewModel>(_produtoService.Obter(id)));
	    }
    }
}