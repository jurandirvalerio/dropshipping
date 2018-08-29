using System.Collections.Generic;

namespace DTOs
{
	public class PedidoFornecedorDTO
	{
		public ClientePedidoFornecedorDTO Cliente { get; set; }
		public EnderecoPedidoFornecedorDTO EnderecoCliente { get; set; }
		public List<ItemPedidoFornecedorDTO> ItensPedido { get; set; }
	}
}