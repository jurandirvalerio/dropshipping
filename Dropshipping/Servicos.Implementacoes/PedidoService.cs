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
		private readonly IApiFornecedorRepository _apiFornecedorRepository;

		public PedidoService(IPedidoRepository pedidoRepository, IPedidoMapper pedidoMapper, IClienteRepository clienteRepository,
			IProdutoFornecedorRepository produtoFornecedorRepository, IApiFornecedorRepository apiFornecedorRepository)
		{
			_pedidoRepository = pedidoRepository;
			_pedidoMapper = pedidoMapper;
			_clienteRepository = clienteRepository;
			_produtoFornecedorRepository = produtoFornecedorRepository;
			_apiFornecedorRepository = apiFornecedorRepository;
		}

		public void Confirmar(PedidoDTO pedidoDto, out int numeroPedido)
		{
			var pedido = _pedidoMapper.Map(pedidoDto);
			pedido.Guid = Guid.NewGuid();
			pedido.CodigoCliente = ObterCodigoCliente(pedidoDto);
			pedido.PedidoItemSet = ObterPedidoItemSet(pedidoDto);
			_pedidoRepository.Add(pedido);
			_pedidoRepository.Save();

			NotificarFornecedor(pedido);
			numeroPedido = pedido.Codigo;
		}

		public PedidoDTO Obter(int codigo)
		{
			var pedido = _pedidoRepository.FindBy(p => p.Codigo == codigo, p => p.PedidoItemSet.Select(pi => pi.Produto)).FirstOrDefault();
			return _pedidoMapper.Map(pedido);
		}

		public List<PedidoDTO> Listar(int codigoCliente)
		{
			var pedidoSet = _pedidoRepository
				.FindBy(p => p.CodigoCliente == codigoCliente, p => p.PedidoItemSet.Select(pi => pi.Produto))
				.OrderByDescending(p => p.DataCriacao)
				.ToList();

			return _pedidoMapper.Map(pedidoSet);
		}

		private void NotificarFornecedor(Pedido pedido)
		{
			var codigoFornecedorSet = pedido.PedidoItemSet.Select(pi => pi.CodigoFornecedor).Distinct();
			var clientePedidoFornecedorDto = ObterClientePedidoFornecedorDto(pedido);
			var enderecoPedidoFornecedorDto = ObterEnderecoPedidoFornecedorDto(pedido);
			foreach (var codigoFornecedor in codigoFornecedorSet)
			{
				var pedidoFornecedorDto = new PedidoFornecedorDTO
				{
					Guid = pedido.Guid,
					Cliente = clientePedidoFornecedorDto,
					EnderecoCliente = enderecoPedidoFornecedorDto,
					ItensPedido = ObterPedidoItemSet(pedido, codigoFornecedor)
				};

				_apiFornecedorRepository.RealizarPedido(pedidoFornecedorDto, codigoFornecedor);
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