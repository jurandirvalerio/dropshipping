using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Areas.Loja.Models
{
	public class ProdutoViewModel
	{
		public int Codigo { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal Valor { get; set; } = 100M;

		public string UrlImagem => UrlImagemDetalheSet.Select(s => s.Url).FirstOrDefault();

		public List<UrlImagemViewModel> UrlImagemDetalheSet { get; set; }
	}
}