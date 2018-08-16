using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
	public class ProdutoFornecedor : Entidade
	{
		[ForeignKey("Produto")]
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		[ForeignKey("Fornecedor")]
		public int CodigoFornecedor { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public decimal PrecoVenda { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public Guid GuidProdutoFornecedor { get; set; }
		public int Quantidade { get; set; }
	}
}