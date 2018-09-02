using System.Collections.Generic;
using DTOs;

namespace Repositorios.Contratos
{
	public interface IApiBiRepository
	{
		void Enviar(List<ProdutoCadastroDTO> produtoCadastradoDtoSet);
		void Enviar(List<ClienteDTO> clienteDtoSet);
		void Enviar(List<PedidoDTO> pedidoDtoSet);
	}
}