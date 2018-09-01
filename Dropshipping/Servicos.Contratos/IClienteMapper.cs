using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IClienteMapper
	{
		ClienteHistorico Map(ClienteDTO clienteDto);

		List<ClienteHistorico> Map(List<ClienteDTO> clienteDto);
	}
}