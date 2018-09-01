using System.Collections.Generic;
using DTOs;

namespace Servicos.Contratos
{
	public interface IPedidoService
	{
		void Confirmar(PedidoDTO pedidoDto, out int numeroPedido);
		PedidoDTO Obter(int codigo);
		List<PedidoDTO> Listar(int codigoCliente);
		List<PedidoDTO> ListarPedidosRealizadosOntem();
	}
}