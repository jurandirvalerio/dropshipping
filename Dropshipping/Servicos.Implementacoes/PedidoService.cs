using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class PedidoService : IPedidoService
	{
		private readonly IPedidoRepository _pedidoRepository;
		private readonly IPedidoMapper _pedidoMapper;
		private readonly IClienteRepository _clienteRepository;
		private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;

		public PedidoService(IPedidoRepository pedidoRepository, IPedidoMapper pedidoMapper, IClienteRepository clienteRepository,
			IProdutoFornecedorRepository produtoFornecedorRepository)
		{
			_pedidoRepository = pedidoRepository;
			_pedidoMapper = pedidoMapper;
			_clienteRepository = clienteRepository;
			_produtoFornecedorRepository = produtoFornecedorRepository;
		}

		public void Confirmar(PedidoDTO pedidoDto)
		{
			var pedido = _pedidoMapper.Map(pedidoDto);
			pedido.CodigoCliente = ObterCodigoCliente(pedidoDto);
			pedido.PedidoItemSet = ObterPedidoItemSet(pedidoDto);
			_pedidoRepository.Add(pedido);
			_pedidoRepository.Save();

			NotificarFornecedor(pedido);
		}

		private void NotificarFornecedor(Pedido pedido)
		{
			var codigoFornecedorSet = pedido.PedidoItemSet.Select(pi => pi.CodigoFornecedor);
			var clientePedidoFornecedorDto = ObterClientePedidoFornecedorDto(pedido);
			var enderecoPedidoFornecedorDto = ObterEnderecoPedidoFornecedorDto(pedido);
			foreach (var codigoFornecedor in codigoFornecedorSet)
			{
				var pedidoFornecedorDto = new PedidoFornecedorDTO
				{
					ClientePedidoFornecedorDto = clientePedidoFornecedorDto,
					EnderecoPedidoFornecedorDto = enderecoPedidoFornecedorDto,
					ItensPedido = ObterPedidoItemSet(pedido, codigoFornecedor)
				};

				// TODO - Enviar para fornecedor
			}
		}

		private List<ItemPedidoFornecedorDTO> ObterPedidoItemSet(Pedido pedido, int codigoFornecedor)
		{
			var itemPedidoFornecedorDtoSet = new List<ItemPedidoFornecedorDTO>();
			var pedidoItemSet = pedido.PedidoItemSet.Where(pi => pi.CodigoFornecedor == codigoFornecedor).ToList();
			foreach (var pedidoItem in pedidoItemSet)
			{
				var guidProduto = _produtoFornecedorRepository.FindBy(pf => pf.CodigoProduto == pedidoItem.CodigoProduto).First().GuidProdutoFornecedor;
				itemPedidoFornecedorDtoSet.Add(new ItemPedidoFornecedorDTO()
				{
					Quantidade = pedidoItem.Quantidade,
					GuidProduto = guidProduto
				});
			}

			return itemPedidoFornecedorDtoSet;
		}

		private static EnderecoPedidoFornecedorDTO ObterEnderecoPedidoFornecedorDto(Pedido pedido)
		{
			return new EnderecoPedidoFornecedorDTO
			{
				Telefone = pedido.Telefone,
				Cidade = pedido.Cidade,
				CEP = pedido.CEP,
				Endereco = pedido.Endereco,
				Bairro = pedido.Bairro
			};
		}

		private static ClientePedidoFornecedorDTO ObterClientePedidoFornecedorDto(Pedido pedido)
		{
			return new ClientePedidoFornecedorDTO { Nome = pedido.Nome, CPF = pedido.CPF };
		}

		private ICollection<PedidoItem> ObterPedidoItemSet(PedidoDTO pedidoDto)
		{
			var pedidoItemSet = new List<PedidoItem>();

			foreach (var itemPedidoDto in pedidoDto.ItensPedido)
			{
				var produtoFornecedor = ObterProdutoFornecedor(itemPedidoDto);
				var itemPedido = new PedidoItem
				{
					DataCriacao = DateTime.Now,
					CodigoFornecedor = produtoFornecedor.CodigoFornecedor,
					CodigoProduto = produtoFornecedor.CodigoProduto,
					Quantidade = itemPedidoDto.Quantidade,
					PrecoCliente = produtoFornecedor.PrecoVenda,
					PrecoFornecedor = produtoFornecedor.PrecoFornecedor
				};
				pedidoItemSet.Add(itemPedido);
			}

			return pedidoItemSet;
		}

		private ProdutoFornecedor ObterProdutoFornecedor(ItemPedidoDTO itemPedidoDto)
		{
			return _produtoFornecedorRepository.FindBy(pf => pf.CodigoProduto == itemPedidoDto.Codigo).FirstOrDefault();
		}

		private int ObterCodigoCliente(PedidoDTO pedidoDto)
		{
			return _clienteRepository.FindBy(c => c.Guid == new Guid(pedidoDto.GuidCliente))
				.Select(c => c.Codigo).FirstOrDefault();
		}
	}
}