using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
	public class PedidoItem : Entidade
	{
		[ForeignKey("Produto")]
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		[ForeignKey("Fornecedor")]
		public int CodigoFornecedor { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public decimal PrecoCliente { get; set; }
		public int Quantidade { get; set; }
		[ForeignKey("Pedido")]
		public int CodigoPedido { get; set; }
		public Pedido Pedido { get; set; }
	}
}