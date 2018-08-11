using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class FornecedorRepository : BaseRepository<Fornecedor, LojaDbContext>, IFornecedorRepository
	{
	}
}