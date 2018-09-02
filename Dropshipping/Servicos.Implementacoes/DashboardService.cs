using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class DashboardService : IDashboardService
	{
		private readonly IClienteHistoricoRepository _clienteHistoricoRepository;
		private readonly IProdutoHistoricoRepository _produtoHistoricoRepository;
		private readonly IPedidoHistoricoRepository _pedidoHistoricoRepository;
		private readonly IItemPedidoHistoricoRepository _itemPedidoHistoricoRepository;

		public DashboardService(IClienteHistoricoRepository clienteHistoricoRepository, 
			IProdutoHistoricoRepository produtoHistoricoRepository, IPedidoHistoricoRepository pedidoHistoricoRepository, IItemPedidoHistoricoRepository itemPedidoHistoricoRepository)
		{
			_clienteHistoricoRepository = clienteHistoricoRepository;
			_produtoHistoricoRepository = produtoHistoricoRepository;
			_pedidoHistoricoRepository = pedidoHistoricoRepository;
			_itemPedidoHistoricoRepository = itemPedidoHistoricoRepository;
		}

		public int ObterNumeroTotalProdutosHistorico()
		{
			return _produtoHistoricoRepository.GetAll().Count();
		}

		public int ObterNumeroTotalVendasHistorico()
		{
			return _pedidoHistoricoRepository.GetAll().Count();
		}

		public decimal ObterValorTotalBrutoVendasHistorico()
		{
			return _pedidoHistoricoRepository.GetAll().Sum(p => p.Total);
		}

		public decimal ObterValorTotalVendasPagasAoFornecedorHistorico()
		{
			return _pedidoHistoricoRepository.GetAll().Sum(p => p.TotalFornecedor);
		}

		public int ObterNumeroTotalClientesHistorico()
		{
			return _clienteHistoricoRepository.GetAll().Count();
		}

		public List<ItemPedidoHistoricoDTO> ObterItensPedido()
		{
			return _itemPedidoHistoricoRepository.GetAll().OrderByDescending(p => p.DataCriacao).Take(5).ToList().Select(Map).ToList();
		}

		private ItemPedidoHistoricoDTO Map(ItemPedidoHistorico itemPedidoHistorico)
		{
			return new ItemPedidoHistoricoDTO
			{
				Produto = itemPedidoHistorico.Nome,
				Fornecedor = itemPedidoHistorico.Fornecedor,
				PrecoVenda = itemPedidoHistorico.Preco,
				PrecoFornecedor = itemPedidoHistorico.PrecoFornecedor,
				Quantidade = itemPedidoHistorico.Quantidade,
				Data = itemPedidoHistorico.DataCriacao.Value
			};
		}
	}
}