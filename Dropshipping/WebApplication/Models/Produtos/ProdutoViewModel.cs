using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Loja.Models.Produtos
{
	public class ProdutoViewModel
	{
		public int Codigo { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal Preco { get; set; }

		public string UrlImagem => UrlImagemSet.FirstOrDefault();

		public List<string> UrlImagemSet { get; set; }
		public string ValorExibicao => Preco.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
	}
}