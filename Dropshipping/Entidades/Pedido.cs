using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
	public class Pedido : Entidade
	{
		[ForeignKey("Cliente")]
		public int CodigoCliente { get; set; }
		public Cliente Cliente { get; set; }
		public ICollection<PedidoItem> PedidoItemSet { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
	}
}