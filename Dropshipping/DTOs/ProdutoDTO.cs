using System.Collections.Generic;

namespace DTOs
{
	public class ProdutoDTO : EntidadeDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public List<string> UrlSet { get; set; }
		public decimal Preco { get; set; }
	}
}