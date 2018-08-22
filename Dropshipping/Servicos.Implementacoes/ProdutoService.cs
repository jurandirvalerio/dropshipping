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
		private readonly IApiFornecedorRepository _apiFornecedorRepository;

		public ProdutoService(IProdutoRepository produtoRepository, IProdutoMapper produtoMapper, IProdutoFornecedorRepository produtoFornecedorRepository, IApiFornecedorRepository apiFornecedorRepository)
		{
			_produtoRepository = produtoRepository;
			_produtoMapper = produtoMapper;
			_produtoFornecedorRepository = produtoFornecedorRepository;
			_apiFornecedorRepository = apiFornecedorRepository;
		}

		public ProdutoDTO Obter(int codigo)
		{
			return _produtoMapper.Map(_produtoRepository.FindBy(p => p.Codigo == codigo, p => p.UrlImagemDetalheSet, p => p.PrecoProdutoFornecedorSet).FirstOrDefault());
		}

		public ProdutoCadastroDTO ObterParaCadastro(int codigo)
		{
			return _produtoFornecedorRepository
				.FindBy(pf => pf.Codigo == codigo)
				.Include(pf => pf.Produto)
				.Include(pf => pf.Fornecedor)
				.Select(pf =>
					new ProdutoCadastroDTO()
					{
						Codigo = pf.Codigo,
						Fornecedor = pf.Fornecedor.Nome,
						Nome = pf.Produto.Nome,
						Descricao = pf.Produto.Descricao,
						PrecoCompra = pf.PrecoFornecedor,
						PrecoVenda = pf.PrecoVenda,
						Ativo = pf.Produto.Visivel
					}
				).FirstOrDefault();
		}

		public List<ProdutoDTO> ListarProdutosEmDestaque()
		{
			return _produtoMapper.Map(QueryProdutosVisiveis().Take(8).OrderByDescending(p => p.DataCriacao).ToList());
		}

		public List<ProdutoDTO> ListarTodosProdutosParaVitrine()
		{
			return _produtoMapper.Map(QueryProdutosVisiveis().ToList());
		}

		public void Alterar(ProdutoCadastroDTO produtoCadastroDto)
		{
			var produtoFornecedor = _produtoFornecedorRepository.FindBy(pf => pf.Codigo == produtoCadastroDto.Codigo).First();
			produtoFornecedor.PrecoVenda = produtoCadastroDto.PrecoVenda;
			_produtoFornecedorRepository.Edit(produtoFornecedor);
			_produtoFornecedorRepository.Save();
			var produto = _produtoRepository.FindBy(p => p.Codigo == produtoFornecedor.CodigoProduto).First();
			var statusInicial = produto.Visivel;
			produto.Nome = produtoCadastroDto.Nome;
			produto.Descricao = produtoCadastroDto.Descricao;
			produto.Visivel = produtoCadastroDto.Ativo;
			_produtoRepository.Edit(produto);
			_produtoRepository.Save();
			VerificarStatusProduto(produtoCadastroDto, produtoFornecedor, statusInicial);
		}

		private void VerificarStatusProduto(ProdutoCadastroDTO produtoCadastroDto, ProdutoFornecedor produtoFornecedor, bool statusInicial)
		{
			if (statusInicial != produtoCadastroDto.Ativo)
			{
				if (produtoCadastroDto.Ativo)
				{
					_apiFornecedorRepository.Subscrever(produtoFornecedor);
				}
				else
				{
					_apiFornecedorRepository.CancelarSubscricao( produtoFornecedor);
				}
			}
		}

		public List<ProdutoCadastroDTO> ListarTodosProdutos()
		{
			return _produtoFornecedorRepository
				.GetAll()
				.Include(pf => pf.Produto)
				.Include(pf => pf.Fornecedor)
				.Select(pf =>
					new ProdutoCadastroDTO()
					{
						Codigo = pf.Codigo,
						Fornecedor = pf.Fornecedor.Nome,
						Nome = pf.Produto.Nome,
						Descricao = pf.Produto.Descricao,
						PrecoCompra = pf.PrecoFornecedor,
						PrecoVenda = pf.PrecoVenda,
						Ativo = pf.Produto.Visivel
					}
				).ToList();
		}

		public void Incluir(ProdutoFornecedorDTO produtoFornecedorDto)
		{
			var produtoFornecedor = new ProdutoFornecedor
			{
				CodigoFornecedor = produtoFornecedorDto.CodigoFornecedor,
				GuidProdutoFornecedor = produtoFornecedorDto.Guid,
				PrecoFornecedor = produtoFornecedorDto.Preco,
				PrecoVenda = produtoFornecedorDto.PrecoSugeridoVenda,
				Estoque = produtoFornecedorDto.Estoque,
				CodigoProduto = ObterCodigoProduto(produtoFornecedorDto)
			};
			_produtoFornecedorRepository.Add(produtoFornecedor);
			_produtoFornecedorRepository.Save();

			_apiFornecedorRepository.Subscrever(produtoFornecedor);
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