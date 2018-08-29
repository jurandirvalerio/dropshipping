using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Loja.Models.Pedido
{
	public class PedidoViewModel
	{
		public int Codigo { get; set; }
		public DateTime Data { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
		public decimal Total => ItensPedido.Sum(ip => ip.Preco);
		public string TotalExibicao => Total.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		public List<ItemPedidoViewModel> ItensPedido { get; set; }
	}
}