using System;

namespace DTOs
{
	public class ProdutoSubscritoDTO
	{
		public Guid Guid { get; set; }
		public decimal Preco { get; set; }
		public decimal PrecoSugeridoVenda { get; set; }
		public int Estoque { get; set; }
	}
}