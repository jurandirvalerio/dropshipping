using System.Collections.Generic;

namespace DTOs
{
	public class FornecedorDTO : EntidadeDTO
	{
		public string Nome { get; set; }
		public List<ProdutoDTO> ProdutoSet { get; set; }
		public string UrlEndpointApi { get; set; }
		public string UsuarioApi { get; set; }
		public string SenhaApi { get; set; }
	}
}