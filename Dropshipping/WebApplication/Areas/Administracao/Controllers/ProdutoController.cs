using System.Web.Mvc;
using DTOs;
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

		public ActionResult Index()
		{
			return View();
		}

	    public ActionResult Listar()
	    {
			return View();
	    }

		[HttpPost]
	    public JsonResult Incluir(ProdutoFornecedorDTO produtoFornecedorDto)
	    {
		    _produtoService.Incluir(produtoFornecedorDto);
		    return Json(true);
	    }
	}
}