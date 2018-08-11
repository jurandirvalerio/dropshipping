using System.ComponentModel.DataAnnotations;

namespace Loja.Areas.Administracao.Models.Fornecedores
{
	public class FornecedorViewModel
	{
		public string Codigo { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		public string Usuario { get; set; }
		[Required]
		public string Senha { get; set; }
		[Required]
		public string UrlEndpoint { get; set; }
	}
}