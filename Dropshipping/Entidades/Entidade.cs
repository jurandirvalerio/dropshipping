using System;

namespace Entidades
{
	public class Entidade
	{
		public int Codigo { get; set; }
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataAtualizacao { get; set; }
		public bool Visivel { get; set; }
	}
}
