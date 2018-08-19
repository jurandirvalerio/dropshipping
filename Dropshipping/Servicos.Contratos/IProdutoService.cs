using System.Collections.Generic;
using DTOs;

namespace Servicos.Contratos
{
	public interface IProdutoService
	{
		ProdutoDTO Obter(int codigo);
		ProdutoCadastroDTO ObterParaCadastro(int codigo);
		List<ProdutoDTO> ListarProdutosEmDestaque();
		List<ProdutoDTO> ListarTodosProdutosParaVitrine();
		void Incluir(ProdutoFornecedorDTO produtoFornecedorDto);
		void Alterar(ProdutoCadastroDTO produtoCadastroDto);
		List<ProdutoCadastroDTO> ListarTodosProdutos();
	}
}