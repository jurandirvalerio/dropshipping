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
	}
}