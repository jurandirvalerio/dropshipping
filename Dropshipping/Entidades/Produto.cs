using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Produto
	{
		[Key]
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public bool Visivel { get; set; }
		public ICollection<UrlImagem> UrlImagemSet { get; set; }
	}
}