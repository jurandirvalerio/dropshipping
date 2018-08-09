using System.Collections.Generic;

namespace Entidades
{
	public class Fornecedor : Entidade
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public ICollection<PrecoProdutoFornecedor> ProdutoSet { get; set; }
	}
}