using System.ComponentModel.DataAnnotations;

namespace Loja.Areas.Administracao.Models.Produto
{
	public class ProdutoViewModel
	{
		[Display(Name = "Código")]
		public int Codigo { get; set; }
		[Required]
		public string Nome { get; set; }
		[Display(Name = "Descrição")]
		[Required]
		public string Descricao { get; set; }
		[Display(Name = "Preço de compra")]
		[DataType(DataType.Currency)]
		public decimal PrecoCompra { get; set; }
		[Display(Name = "Preço de venda")]
		[DataType(DataType.Currency)]
		[Required]
		public decimal PrecoVenda { get; set; }
		public string Fornecedor { get; set; }
		public bool Ativo { get; set; }
	}
}