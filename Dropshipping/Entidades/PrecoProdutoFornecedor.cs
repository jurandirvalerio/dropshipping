using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
	public class PrecoProdutoFornecedor : Entidade
	{
		[ForeignKey("Produto")]
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		[ForeignKey("Fornecedor")]
		public int CodigoFornecedor { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public decimal Preco { get; set; }
		public int Quantidade { get; set; }
	}
}