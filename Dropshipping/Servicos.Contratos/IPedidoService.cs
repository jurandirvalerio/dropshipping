using DTOs;

namespace Servicos.Contratos
{
	public interface IPedidoService
	{
		void Confirmar(PedidoDTO pedidoDto, out int numeroPedido);

		PedidoDTO Obter(int codigo);
	}
}