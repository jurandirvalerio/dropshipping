using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IClienteService
	{
		void Cadastrar(Cliente cliente);
		void CadastrarHistorico(ClienteHistorico clienteHistorico);
		string ObterNomeCliente(string email);
		int ObterCodigoCliente(string email);
		List<ClienteDTO> ListarClientesCadastradosOntem();
		bool JaEnviouDadosAoBIHoje();
	}
}