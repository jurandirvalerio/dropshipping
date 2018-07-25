using System.Web.Mvc;
using AutoMapper;
using Entidades;
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
            return View();
        }

	    public ActionResult Detalhe(int id)
	    {
			return View(Mapper.Map<Produto, ProdutoViewModel>(_produtoService.Obter(id)));
	    }
    }
}