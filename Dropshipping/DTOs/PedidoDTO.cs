using System.Collections.Generic;

namespace DTOs
{
	public class PedidoDTO
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
		public List<ItemPedidoDTO> ItensPedido { get; set; }
		public string GuidCliente { get; set; }
	}
}