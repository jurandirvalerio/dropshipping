using System.Linq;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ProdutoFornecedorService : IProdutoFornecedorService
	{
		private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoFornecedorService(IProdutoFornecedorRepository produtoFornecedorRepository, IProdutoRepository produtoRepository)
		{
			_produtoFornecedorRepository = produtoFornecedorRepository;
			_produtoRepository = produtoRepository;
		}

		public void AtualizarProduto(ProdutoSubscritoDTO produtoSubscritoDto)
		{
			var produtoFornecedor = ObterProdutoFornecedor(produtoSubscritoDto);
			Map(produtoFornecedor, produtoSubscritoDto);
			_produtoFornecedorRepository.Edit(produtoFornecedor);
			_produtoFornecedorRepository.Save();

			ValidarEstoque(produtoFornecedor);
		}

		private void ValidarEstoque(ProdutoFornecedor produtoFornecedor)
		{
			if (produtoFornecedor.Estoque < 1)
			{
				var produto = _produtoRepository.FindBy(p => p.Codigo == produtoFornecedor.CodigoProduto).First();
				produto.Visivel = false;
				_produtoRepository.Edit(produto);
				_produtoRepository.Save();
			}
		}

		private void Map(ProdutoFornecedor produtoFornecedor, ProdutoSubscritoDTO produtoSubscritoDto)
		{
			produtoFornecedor.Estoque = produtoSubscritoDto.Estoque;
			produtoFornecedor.PrecoFornecedor = produtoSubscritoDto.Preco;
			produtoFornecedor.PrecoVenda = produtoSubscritoDto.PrecoSugeridoVenda;
		}

		private ProdutoFornecedor ObterProdutoFornecedor(ProdutoSubscritoDTO produtoSubscritoDto)
		{
			return _produtoFornecedorRepository
				.FindBy(pf => pf.GuidProdutoFornecedor == produtoSubscritoDto.Guid).FirstOrDefault();
		}
	}
}