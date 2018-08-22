using System;

namespace DTOs
{
	public class PublisherSubscriberDTO
	{
		public Guid Guid { get; set; }
		public string Url { get; set; }
		public decimal Preco { get; set; }
		public int Estoque { get; set; }
	}
}