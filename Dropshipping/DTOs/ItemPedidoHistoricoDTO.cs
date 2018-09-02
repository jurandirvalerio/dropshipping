using System;

namespace DTOs
{
	public class ItemPedidoHistoricoDTO
	{
		public string Fornecedor { get; set; }
		public string Produto { get; set; }
		public decimal PrecoVenda { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public DateTime Data { get; set; }
		public int Quantidade { get; set; }
	}
}