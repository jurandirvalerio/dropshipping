using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Loja.Areas.Administracao.Models.Home;
using Loja.Infrastructure.Authentication;
using Servicos.Contratos;

namespace Loja.Areas.Administracao.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class HomeController : Controller
	{
		private readonly IDashboardService _dashboardService;

		public HomeController(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		public ActionResult Index()
        {
            return View(PopularModel());
        }

		private DashboardViewModel PopularModel()
		{
			var dashboardViewModel =
				new DashboardViewModel
				{
					NumeroClientes = _dashboardService.ObterNumeroTotalClientesHistorico(),
					NumeroDeVendas = _dashboardService.ObterNumeroTotalVendasHistorico(),
					NumeroProdutos = _dashboardService.ObterNumeroTotalProdutosHistorico(),
					TotalBrutoEmVendas = _dashboardService.ObterValorTotalBrutoVendasHistorico(),
					TotalPagoAoFornecedor = _dashboardService.ObterValorTotalVendasPagasAoFornecedorHistorico(),
				};

			dashboardViewModel.VendaDashboardViewModelSet = Mapper.Map<List<VendaDashboardViewModel>>(_dashboardService.ObterItensPedido()); 
			return dashboardViewModel;
		}
	}
}