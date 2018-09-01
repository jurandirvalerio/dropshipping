using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IPedidoMapper
	{
		Pedido Map(PedidoDTO pedidoDto);
		PedidoDTO Map(Pedido pedido);
		List<PedidoDTO> Map(List<Pedido> pedidoSet);
		List<PedidoHistorico> MapPedidoHistorico(List<PedidoDTO> pedidos);
		List<ItemPedidoHistorico> MapItemPedidoHistorico(List<PedidoDTO> pedidos);
	}
}