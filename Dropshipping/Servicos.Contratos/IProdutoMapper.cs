using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IProdutoMapper
	{
		ProdutoDTO Map(Produto produto);
		List<ProdutoDTO> Map(List<Produto> produtoSet);
		ProdutoHistorico Map(ProdutoCadastroDTO produtoCadastroDto);
		List<ProdutoHistorico> Map(List<ProdutoCadastroDTO> produtoCadastroDtoSet);
	}
}