using System;

namespace FornecedorAPI.Models
{
	/// <summary>
	/// Item que compõe um pedido
	/// </summary>
	public class ItemPedido
	{
		/// <summary>
		/// Identificação do produto
		/// </summary>
		public Guid GuidProduto { get; set; }
		/// <summary>
		/// Quantidade do produto
		/// </summary>
		public int Quantidade { get; set; }
	}
}