using System.ComponentModel.DataAnnotations;

namespace Loja.Areas.Administracao.Models.Fornecedor
{
	public class FornecedorViewModel
	{
		public int Codigo { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		[Display(Name = "Usuário")]
		public string UsuarioApi { get; set; }
		[Required]
		[Display(Name = "Senha")]
		public string SenhaApi { get; set; }
		[Required]
		[Display(Name = "Endpoint")]
		public string UrlEndpointApi { get; set; }
	}
}