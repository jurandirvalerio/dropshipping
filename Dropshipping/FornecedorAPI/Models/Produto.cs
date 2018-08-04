using System;
using System.Collections.Generic;

namespace FornecedorAPI.Models
{
	/// <summary>
	/// Produto disponível para venda
	/// </summary>
	public class Produto
	{
		/// <summary>
		/// Identificação do produto
		/// </summary>
		public Guid Guid { get; set; }
		/// <summary>
		/// Nome do produto
		/// </summary>
		public string Nome { get; set; }
		/// <summary>
		/// Descrição do produto
		/// </summary>
		public string Descricao { get; set; }
		/// <summary>
		/// Preço de custo do produto
		/// </summary>
		public decimal Preco { get; set; }
		/// <summary>
		/// Quantidade disponível para venda
		/// </summary>
		public int Estoque { get; set; }
		/// <summary>
		/// Sugestão de valor de venda
		/// </summary>
		public decimal PrecoSugeridoVenda { get; set; }
		/// <summary>
		/// Lista de urls com imagens do produto
		/// </summary>
		public List<string> Imagens { get; set; } = new List<string>();
	}
}