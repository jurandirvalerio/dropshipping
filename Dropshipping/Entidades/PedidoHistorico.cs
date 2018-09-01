using System;
using System.Collections.Generic;

namespace Entidades
{
	public class PedidoHistorico : Entidade
	{
		public DateTime? Data { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string CEP { get; set; }
		public decimal Total { get; set; }
		public decimal TotalFornecedor { get; set; }
		public decimal LucroLiquido { get; set; }
		public string GuidCliente { get; set; }
	}
}