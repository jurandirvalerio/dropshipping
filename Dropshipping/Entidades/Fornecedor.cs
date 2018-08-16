using System.Collections.Generic;

namespace Entidades
{
	public class Fornecedor : Entidade
	{
		public string Nome { get; set; }
		public string UrlEndpointApi { get; set; }
		public string UsuarioApi { get; set; }
		public string SenhaApi { get; set; }
		public ICollection<ProdutoFornecedor> ProdutoSet { get; set; }
	}
}