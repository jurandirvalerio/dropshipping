namespace FornecedorAPI.Models
{
	/// <summary>
	/// Endereço do cliente para entrega dos itens de pedido
	/// </summary>
	public class EnderecoCliente
	{
		/// <summary>
		/// Telefone para contato na entrega
		/// </summary>
		public string Telefone { get; set; }
		/// <summary>
		/// Endereço de entrega
		/// </summary>
		public string Endereco { get; set; }
		/// <summary>
		/// Bairro de entrega
		/// </summary>
		public string Bairro { get; set; }
		/// <summary>
		/// Cidade de entrega
		/// </summary>
		public string Cidade { get; set; }
		/// <summary>
		/// CEP de entrega
		/// </summary>
		public string CEP { get; set; }
	}
}