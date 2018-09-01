using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ClienteMapper : IClienteMapper
	{
		public ClienteHistorico Map(ClienteDTO clienteDto)
		{
			return new ClienteHistorico
			{
				Guid = clienteDto.Guid,
				Nome = clienteDto.Nome,
				CPF = clienteDto.CPF,
				Codigo = clienteDto.Codigo,
				Visivel = clienteDto.Visivel,
				DataCriacao = clienteDto.DataCriacao,
				DataAtualizacao = clienteDto.DataAtualizacao,
				Email = clienteDto.Email
			};
		}

		public List<ClienteHistorico> Map(List<ClienteDTO> clienteDto)
		{
			return clienteDto.Select(Map).ToList();
		}
	}
}