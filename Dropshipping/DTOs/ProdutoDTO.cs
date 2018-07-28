using System;
using System.Collections.Generic;

namespace DTOs
{
	public class ProdutoDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public List<string> UrlSet { get; set; }
		public decimal Preco { get; set; }
		public int Codigo { get; set; }
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataAtualizacao { get; set; }
	}
}