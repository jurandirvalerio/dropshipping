using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoService : IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;
		private readonly IProdutoMapper _produtoMapper;

		public ProdutoService(IProdutoRepository produtoRepository, IProdutoMapper produtoMapper)
		{
			_produtoRepository = produtoRepository;
			_produtoMapper = produtoMapper;
		}

		public ProdutoDTO Obter(int codigo)
		{
			return _produtoMapper.Map(_produtoRepository.FindBy(p => p.Codigo == codigo, p => p.UrlImagemDetalheSet, p => p.PrecoProdutoFornecedorSet).FirstOrDefault());
		}

		public List<ProdutoDTO> ListarProdutosEmDestaque()
		{
			return _produtoMapper.Map(QueryProdutosVisiveis().Take(8).OrderByDescending(p => p.DataCriacao).ToList());
		}

		public List<ProdutoDTO> ListarTodosProdutos()
		{
			return _produtoMapper.Map(QueryProdutosVisiveis().ToList());
		}

		private IQueryable<Produto> QueryProdutosVisiveis()
		{
			return _produtoRepository.GetAll()
				.Where(p => p.Visivel)
				.Include(p => p.UrlImagemDetalheSet)
				.Include(p => p.PrecoProdutoFornecedorSet);
		}
	}
}