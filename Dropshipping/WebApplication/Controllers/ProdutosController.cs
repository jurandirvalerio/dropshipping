using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Servicos.Contratos;
using WebApplication.Models.Produtos;

namespace WebApplication.Controllers
{
    public class ProdutosController : Controller
    {
	    private readonly IProdutoService _produtoService;

	    public ProdutosController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

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