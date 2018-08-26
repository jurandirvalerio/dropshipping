using DTOs;

namespace Servicos.Contratos
{
	public interface IPedidoService
	{
		void Confirmar(PedidoDTO pedidoDto);
	}
}