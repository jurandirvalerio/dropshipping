using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ProdutoFornecedorRepository : BaseRepository<ProdutoFornecedor, LojaDbContext>, IProdutoFornecedorRepository
	{
	}
}