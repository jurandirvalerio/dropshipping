using System.Collections.Generic;
using Entidades;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		Produto Obter(int codigo);
		List<Produto> ListarProdutosEmDestaque();
		List<Produto> ListarTodosProdutos();
	}
}