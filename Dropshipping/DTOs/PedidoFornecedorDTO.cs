using System.Collections.Generic;

namespace DTOs
{
	public class PedidoFornecedorDTO
	{
		public ClientePedidoFornecedorDTO ClientePedidoFornecedorDto { get; set; }
		public EnderecoPedidoFornecedorDTO EnderecoPedidoFornecedorDto { get; set; }
		public List<ItemPedidoFornecedorDTO> ItensPedido { get; set; }
	}
}