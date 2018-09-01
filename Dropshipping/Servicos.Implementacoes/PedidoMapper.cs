using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class PedidoMapper : IPedidoMapper
	{
		public Pedido Map(PedidoDTO pedidoDto)
		{
			return new Pedido
			{
				Bairro = pedidoDto.Bairro,
				CEP = pedidoDto.CEP,
				CPF = pedidoDto.CPF,
				Endereco = pedidoDto.Endereco,
				Cidade = pedidoDto.Cidade,
				Nome = pedidoDto.Nome,
				Telefone = pedidoDto.Telefone,
				Codigo = pedidoDto.Codigo,
				DataCriacao = pedidoDto.DataCriacao,
				DataAtualizacao = pedidoDto.DataAtualizacao,
				Visivel = pedidoDto.Visivel
			};
		}

		public List<PedidoDTO> Map(List<Pedido> pedidoSet)
		{
			return pedidoSet.Select(Map).ToList();
		}

		public PedidoHistorico MapPedidoHistorico(PedidoDTO pedidoDto)
		{
			return new PedidoHistorico
			{
				Nome = pedidoDto.Nome,
				Codigo = pedidoDto.Codigo,
				DataCriacao = pedidoDto.DataCriacao,
				Visivel = pedidoDto.Visivel,
				DataAtualizacao = pedidoDto.DataAtualizacao,
				CPF = pedidoDto.CPF,
				Endereco = pedidoDto.Endereco,
				Bairro = pedidoDto.Bairro,
				CEP = pedidoDto.CEP,
				Cidade = pedidoDto.Cidade,
				Telefone = pedidoDto.Telefone,
				Total = pedidoDto.Total,
				TotalFornecedor = pedidoDto.TotalFornecedor,
				Data = pedidoDto.Data,
				GuidCliente = pedidoDto.GuidCliente,
				LucroLiquido = pedidoDto.LucroLiquido
			};
		}

		public List<PedidoHistorico> MapPedidoHistorico(List<PedidoDTO> pedidos)
		{
			return pedidos.Select(MapPedidoHistorico).ToList();
		}

		public ItemPedidoHistorico MapItemPedidoHistorico(ItemPedidoDTO itemPedidoDto)
		{
			return new ItemPedidoHistorico
			{
				Fornecedor = itemPedidoDto.Fornecedor,
				Nome = itemPedidoDto.Nome,
				Codigo = itemPedidoDto.Codigo,
				DataCriacao = itemPedidoDto.DataCriacao,
				Visivel = itemPedidoDto.Visivel,
				DataAtualizacao = itemPedidoDto.DataAtualizacao,
				Preco = itemPedidoDto.Preco,
				Quantidade = itemPedidoDto.Quantidade,
				PrecoFornecedor = itemPedidoDto.PrecoFornecedor
			};
		}

		public List<ItemPedidoHistorico> MapItemPedidoHistorico(List<PedidoDTO> pedidos)
		{
			return pedidos.SelectMany(p => p.ItensPedido).Select(MapItemPedidoHistorico).ToList();
		}

		public PedidoDTO Map(Pedido pedido)
		{
			return new PedidoDTO
			{
				Bairro = pedido.Bairro,
				CEP = pedido.CEP,
				CPF = pedido.CPF,
				Endereco = pedido.Endereco,
				Cidade = pedido.Cidade,
				Nome = pedido.Nome,
				Telefone = pedido.Telefone,
				Data = pedido.DataCriacao,
				Codigo = pedido.Codigo,
				ItensPedido = Map(pedido.PedidoItemSet),
				DataCriacao = pedido.DataCriacao,
				DataAtualizacao = pedido.DataAtualizacao,
				Visivel = pedido.Visivel
			};
		}

		private static List<ItemPedidoDTO> Map(IEnumerable<PedidoItem> pedidoItemSet)
		{
			return pedidoItemSet.Select(pedidoItem => new ItemPedidoDTO
			{
				Codigo = pedidoItem.CodigoProduto,
				Nome = pedidoItem.Produto?.Nome,
				Preco = pedidoItem.PrecoCliente,
				Quantidade = pedidoItem.Quantidade,
				PrecoFornecedor = pedidoItem.PrecoFornecedor,
				Fornecedor = pedidoItem.Fornecedor?.Nome,
				DataCriacao = pedidoItem.DataCriacao,
				Visivel = pedidoItem.Visivel,
				DataAtualizacao = pedidoItem.DataAtualizacao
			}).ToList();
		}
	}
}