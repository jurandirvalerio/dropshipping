namespace DTOs
{
	public class ProdutoCadastroDTO
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public decimal PrecoCompra { get; set; }
		public decimal PrecoVenda { get; set; }
		public string Fornecedor { get; set; }
		public bool Ativo { get; set; }
	}
}