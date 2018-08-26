using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IPedidoMapper
	{
		Pedido Map(PedidoDTO pedidoDto);
	}
}