using System.Collections.Generic;

namespace Entidades
{
	public class Fornecedor : Entidade
	{
		public string Nome { get; set; }
		public ICollection<PrecoProdutoFornecedor> ProdutoSet { get; set; }
	}
}