using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Areas.Loja.Models
{
	public class ProdutoViewModel
	{
		public int Codigo { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal Valor { get; set; }

		public string UrlImagemPrincipal => UrlImagemSet.FirstOrDefault();

		public List<string> UrlImagemSet { get; set; }
	}
}