using System;
using System.Collections.Generic;

namespace FornecedorAPI.Models
{
	/// <summary>
	/// Solicitação para envio de itens para um cliente
	/// </summary>
	public class Pedido
	{
		/// <summary>
		/// Identificador do pedido
		/// </summary>
		public Guid Guid { get; set; }
		/// <summary>
		/// Cliente para quem será enviado o pedido
		/// </summary>
		public Cliente Cliente { get; set; }
		/// <summary>
		/// Endereço de envio do pedido
		/// </summary>
		public EnderecoCliente EnderecoCliente { get; set; }
		/// <summary>
		/// Itens que compõem o pedido
		/// </summary>
		public List<ItemPedido> ItensPedido { get; set; }
	}
}