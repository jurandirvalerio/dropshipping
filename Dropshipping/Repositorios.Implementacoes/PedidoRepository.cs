using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class PedidoRepository : BaseRepository<Pedido, LojaDbContext>, IPedidoRepository
	{
	}
}