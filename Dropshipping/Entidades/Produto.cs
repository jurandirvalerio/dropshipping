using System.Collections.Generic;

namespace Entidades
{
	public class Produto : Entidade
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public ICollection<UrlImagem> UrlImagemDetalheSet { get; set; }
		public ICollection<ProdutoFornecedor> PrecoProdutoFornecedorSet { get; set; }
	}
}