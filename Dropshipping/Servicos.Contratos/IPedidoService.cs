using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IPedidoService
	{
		void Confirmar(PedidoDTO pedidoDto, out int numeroPedido);
		PedidoDTO Obter(int codigo);
		List<PedidoDTO> Listar(int codigoCliente);
		List<PedidoDTO> ListarPedidosRealizadosOntem();
		void CadastrarHistorico(PedidoHistorico pedidoHistorico);
		void CadastrarHistorico(ItemPedidoHistorico itemPedidoHistorico);
		bool JaEnviouDadosAoBIHoje();
	}
}