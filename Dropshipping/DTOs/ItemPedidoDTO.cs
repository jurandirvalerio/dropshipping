namespace DTOs
{
	public class ItemPedidoDTO
	{
		public int Codigo { get; set; }
		public int Quantidade { get; set; }
		public decimal Preco { get; set; }
		public string Nome { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public string Fornecedor { get; set; }
	}
}