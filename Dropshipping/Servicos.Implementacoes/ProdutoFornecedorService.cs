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

		public void AtualizarProduto(PublisherSubscriberDTO publisherSubscriberDto)
		{
			var produtoFornecedor = ObterProdutoFornecedor(publisherSubscriberDto);
			Map(produtoFornecedor, publisherSubscriberDto);
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

		private void Map(ProdutoFornecedor produtoFornecedor, PublisherSubscriberDTO publisherSubscriberDto)
		{
			produtoFornecedor.Estoque = publisherSubscriberDto.Estoque;
			produtoFornecedor.PrecoFornecedor = publisherSubscriberDto.Preco;
		}

		private ProdutoFornecedor ObterProdutoFornecedor(PublisherSubscriberDTO publisherSubscriberDto)
		{
			return _produtoFornecedorRepository
				.FindBy(pf => pf.GuidProdutoFornecedor == publisherSubscriberDto.Guid).FirstOrDefault();
		}
	}
}