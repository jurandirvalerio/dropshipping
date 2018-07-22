using Entidades;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		Produto Obter(int codigo);
	}
}