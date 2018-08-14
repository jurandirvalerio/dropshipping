using System;
using System.Collections.Generic;

namespace DTOs
{
	public class ProdutoFornecedorDTO
	{
		public Guid Guid { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public decimal Preco { get; set; }
		public int Estoque { get; set; }
		public decimal PrecoSugeridoVenda { get; set; }
		public List<string> Imagens { get; set; } = new List<string>();
	}
}
