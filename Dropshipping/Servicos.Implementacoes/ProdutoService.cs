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
		private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;
		private readonly IProdutoRepository _produtoRepository;
		private readonly IProdutoMapper _produtoMapper;

		public ProdutoService(IProdutoRepository produtoRepository, IProdutoMapper produtoMapper, IProdutoFornecedorRepository produtoFornecedorRepository)
		{
			_produtoRepository = produtoRepository;
			_produtoMapper = produtoMapper;
			_produtoFornecedorRepository = produtoFornecedorRepository;
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

		public void Incluir(ProdutoFornecedorDTO produtoFornecedorDto)
		{
			var produtoFornecedor = new ProdutoFornecedor
			{
				CodigoFornecedor = produtoFornecedorDto.CodigoFornecedor,
				GuidProdutoFornecedor = produtoFornecedorDto.Guid,
				PrecoFornecedor = produtoFornecedorDto.Preco,
				PrecoVenda = produtoFornecedorDto.PrecoSugeridoVenda,
				Quantidade = produtoFornecedorDto.Estoque,
				CodigoProduto = ObterCodigoProduto(produtoFornecedorDto)
			};
			_produtoFornecedorRepository.Add(produtoFornecedor);
			_produtoFornecedorRepository.Save();
		}

		private int ObterCodigoProduto(ProdutoFornecedorDTO produtoFornecedorDto)
		{
			var produto = _produtoRepository.FindBy(p => p.Nome == produtoFornecedorDto.Nome).FirstOrDefault();
			return produto?.Codigo ?? CriarProduto(produtoFornecedorDto);
		}

		private int CriarProduto(ProdutoFornecedorDTO produtoFornecedorDto)
		{
			var produto = new Produto()
			{
				Nome = produtoFornecedorDto.Nome,
				Descricao = produtoFornecedorDto.Descricao,
				UrlImagemDetalheSet = MapearImagensProduto(produtoFornecedorDto)
			};
			
			_produtoRepository.Add(produto);
			_produtoRepository.Save();

			return produto.Codigo;
		}

		private ICollection<UrlImagem> MapearImagensProduto(ProdutoFornecedorDTO produtoFornecedorDto)
		{
			if (produtoFornecedorDto.Imagens.Count == 0) return null;

			var imagens = new List<UrlImagem>();
			foreach (var imagen in produtoFornecedorDto.Imagens)
			{
				imagens.Add(new UrlImagem(imagen));
			}
			return imagens;
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