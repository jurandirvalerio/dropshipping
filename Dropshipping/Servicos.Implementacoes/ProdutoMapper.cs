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
				Preco = produto.PrecoProdutoFornecedorSet.Min(p => p.Preco),
				DataAtualizacao = produto.DataAtualizacao,
				UrlSet = produto.UrlImagemDetalheSet.Select(u => u.Url).ToList()
			};
		}

		public List<ProdutoDTO> Map(List<Produto> produtoSet)
		{
			var produtoDTOSet = new List<ProdutoDTO>();

			foreach (var produto in produtoSet)
			{
				produtoDTOSet.Add(Map(produto));
			}

			return produtoDTOSet;
		}
	}
}