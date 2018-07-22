using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ProdutoRepository : BaseRepository<Produto, LojaDbContext>, IProdutoRepository
	{
	}
}