using System.Collections.Generic;
using System.Globalization;

namespace Loja.Areas.Administracao.Models.Home
{
	public class DashboardViewModel
	{
		public decimal TotalBrutoEmVendas { get; set; }
		public string TotalEmVendasExibicao => TotalBrutoEmVendas.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public decimal TotalPagoAoFornecedor { get; set; }
		public string TotalPagoAoFornecedorExibicao => TotalPagoAoFornecedor.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public decimal TotalLiquido => TotalBrutoEmVendas - TotalPagoAoFornecedor;
		public string TotalLiquidoExibicao => TotalLiquido.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public int NumeroDeVendas { get; set; }
		public int NumeroProdutos { get; set; }
		public int NumeroClientes { get; set; }
		public List<VendaDashboardViewModel> VendaDashboardViewModelSet { get; set; } = new List<VendaDashboardViewModel>();
	}
}