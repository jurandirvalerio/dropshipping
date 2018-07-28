using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		ProdutoDTO Obter(int codigo);
		List<ProdutoDTO> ListarProdutosEmDestaque();
		List<ProdutoDTO> ListarTodosProdutos();
	}
}