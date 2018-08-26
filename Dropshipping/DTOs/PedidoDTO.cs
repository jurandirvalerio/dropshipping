using System.Collections.Generic;

namespace DTOs
{
	public class PedidoDTO
	{
		public string PrimeiroNome { get; set; }
		public string Sobrenome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
		public List<ItemPedidoDTO> ItensPedido { get; set; }
	}
}