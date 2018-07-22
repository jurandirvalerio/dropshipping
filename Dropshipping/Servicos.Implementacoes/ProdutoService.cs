using System.Linq;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoService : IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoService(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public Produto Obter(int codigo)
		{
			return _produtoRepository.FindBy(p => p.Codigo == codigo).FirstOrDefault();
		}
	}
}