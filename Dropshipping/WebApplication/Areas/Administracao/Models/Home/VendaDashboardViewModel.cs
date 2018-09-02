using System;
using System.Globalization;

namespace Loja.Areas.Administracao.Models.Home
{
	public  class VendaDashboardViewModel
	{
		public string Fornecedor { get; set; }
		public string Produto { get; set; }
		public decimal PrecoVenda { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public string PrecoFornecedorExibicao => PrecoFornecedor.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public int Quantidade { get; set; }
		public string PrecoVendaExibicao => PrecoVenda.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public DateTime Data { get; set; }
	}
}