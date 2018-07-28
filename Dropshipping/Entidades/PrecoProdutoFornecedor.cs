namespace Entidades
{
	public class PrecoProdutoFornecedor : Entidade
	{
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		public int CodigoFornecedor { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public decimal Preco { get; set; }
	}
}