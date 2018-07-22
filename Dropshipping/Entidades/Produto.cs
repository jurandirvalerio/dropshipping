using System.Collections.Generic;

namespace Entidades
{
	public class Produto
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public bool Visivel { get; set; }
		public ICollection<UrlImagem> UrlImagemSet { get; set; }
	}
}