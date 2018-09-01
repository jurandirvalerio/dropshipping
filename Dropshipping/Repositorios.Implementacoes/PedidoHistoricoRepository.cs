using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class PedidoHistoricoRepository : BaseRepository<PedidoHistorico, LojaDbContext>, IPedidoHistoricoRepository
	{
	}
}