using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoMapper : IProdutoMapper
	{
		public ProdutoDTO Map(Produto produto)
		{
			return new ProdutoDTO
			{
				Codigo = produto.Codigo,
				Nome = produto.Nome,
				DataCriacao = produto.DataCriacao,
				Descricao = produto.Descricao,
				Preco = produto.PrecoProdutoFornecedorSet.Min(p => p.PrecoVenda),
				DataAtualizacao = produto.DataAtualizacao,
				UrlSet = produto.UrlImagemDetalheSet.Select(u => u.Url).ToList()
			};
		}

		public List<ProdutoDTO> Map(List<Produto> produtoSet)
		{
			return produtoSet.Select(Map).ToList();
		}

		public ProdutoHistorico Map(ProdutoCadastroDTO produtoCadastroDto)
		{
			return new ProdutoHistorico
			{
				Fornecedor = produtoCadastroDto.Fornecedor,
				Nome = produtoCadastroDto.Nome,
				Codigo = produtoCadastroDto.Codigo,
				DataCriacao = produtoCadastroDto.DataCriacao,
				Visivel = produtoCadastroDto.Visivel,
				DataAtualizacao = produtoCadastroDto.DataAtualizacao,
				Descricao = produtoCadastroDto.Descricao,
				PrecoVenda = produtoCadastroDto.PrecoVenda,
				Ativo = produtoCadastroDto.Ativo,
				PrecoCompra = produtoCadastroDto.PrecoCompra
			};
		}

		public List<ProdutoHistorico> Map(List<ProdutoCadastroDTO> produtoCadastroDtoSet)
		{
			return produtoCadastroDtoSet.Select(Map).ToList();
		}
	}
}