using System;

namespace DTOs
{
	public class EntidadeDTO
	{
		public int Codigo { get; set; }
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataAtualizacao { get; set; }
		public bool Visivel { get; set; }
	}
}