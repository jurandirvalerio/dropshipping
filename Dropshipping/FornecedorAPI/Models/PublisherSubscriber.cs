using System;

namespace FornecedorAPI.Models
{
	/// <summary>
	/// Modelo para subscrição em um produto
	/// Uma vez realizada a subscrição o solicitante receberá via post na url informada informações sobre alteração no preço e estoque de um item
	/// </summary>
	public class PublisherSubscriber
	{
		/// <summary>
		/// Identificação do produto
		/// </summary>
		public Guid Guid { get; set; }
		/// <summary>
		/// URL para o webhook - onde serão postadas alterações no produto
		/// </summary>
		public string Url { get; set; }
	}
}