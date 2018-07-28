using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoService : IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoService(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public Produto Obter(int codigo)
		{
			return _produtoRepository.FindBy(p => p.Codigo == codigo, p => p.UrlImagemDetalheSet).FirstOrDefault();
		}

		public List<Produto> ListarProdutosEmDestaque()
		{
			return QueryProdutosVisiveis().Take(8).OrderByDescending(p => p.DataCriacao).ToList();
		}

		public List<Produto> ListarTodosProdutos()
		{
			return QueryProdutosVisiveis().ToList();
		}

		private IQueryable<Produto> QueryProdutosVisiveis()
		{
			return _produtoRepository.GetAll().Where(p => p.Visivel).Include(p => p.UrlImagemDetalheSet);
		}
	}
}