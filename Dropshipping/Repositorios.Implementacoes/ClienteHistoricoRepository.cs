using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ClienteHistoricoRepository : BaseRepository<ClienteHistorico, LojaDbContext>, IClienteHistoricoRepository
	{
	}
}