using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ProdutoHistoricoRepository : BaseRepository<ProdutoHistorico, LojaDbContext>, IProdutoHistoricoRepository
	{
	}
}