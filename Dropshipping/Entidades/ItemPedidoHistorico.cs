﻿namespace Entidades
{
	public class ItemPedidoHistorico : Entidade
	{
		public int Quantidade { get; set; }
		public decimal Preco { get; set; }
		public string Nome { get; set; }
		public decimal PrecoFornecedor { get; set; }
		public string Fornecedor { get; set; }
	}
}