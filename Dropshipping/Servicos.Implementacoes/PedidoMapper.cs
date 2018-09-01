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
				Telefone = pedidoDto.Telefone
			};
		}

		public List<PedidoDTO> Map(List<Pedido> pedidoSet)
		{
			var pedidoDtoSet = new List<PedidoDTO>();

			foreach (var pedido in pedidoSet)
			{
				pedidoDtoSet.Add(Map(pedido));
			}

			return pedidoDtoSet;
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
				ItensPedido = Map(pedido.PedidoItemSet)
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
				Fornecedor = pedidoItem.Fornecedor?.Nome
			}).ToList();
		}
	}
}