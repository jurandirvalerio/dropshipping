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
			return _produtoRepository.GetAll().Include(p => p.UrlImagemDetalheSet).Take(8).OrderByDescending(p => p.DataCriacao).ToList();
		}
	}
}