using System.Globalization;

namespace Loja.Models.Pedido
{
	public class ItemPedidoViewModel
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public decimal Preco { get; set; }
		public string PrecoExibicao => Preco.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
	}
}