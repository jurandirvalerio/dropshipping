namespace DTOs
{
	public class ProdutoCadastroDTO : EntidadeDTO
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public decimal PrecoCompra { get; set; }
		public decimal PrecoVenda { get; set; }
		public string Fornecedor { get; set; }
		public bool Ativo { get; set; }
	}
}