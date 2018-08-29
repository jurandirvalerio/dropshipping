namespace FornecedorAPI.Models
{
	/// <summary>
	/// Pessoa para quem o pedido será enviado
	/// </summary>
	public class Cliente
	{
		/// <summary>
		/// Nome do cliente
		/// </summary>
		public string Nome { get; set; }
		/// <summary>
		/// CPF do cliente
		/// </summary>
		public string CPF { get; set; }
	}
}