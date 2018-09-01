using System;
using System.Collections.Generic;
using System.Linq;

namespace DTOs
{
	public class PedidoDTO : EntidadeDTO
	{
		public DateTime? Data { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
		public List<ItemPedidoDTO> ItensPedido { get; set; }
		public decimal Total => ItensPedido.Sum(ip => ip.Preco);
		public decimal TotalFornecedor => ItensPedido.Sum(ip => ip.PrecoFornecedor);
		public decimal LucroLiquido => Total - TotalFornecedor;
		public string GuidCliente { get; set; }
	}
}