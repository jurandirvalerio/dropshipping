using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteService(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public string ObterNomeCliente(string email)
		{
			return _clienteRepository
				.FindBy(c => c.Email.ToUpper() == email.ToUpper()).Select(c => c.Nome)
				.FirstOrDefault();
		}

		public int ObterCodigoCliente(string email)
		{
			return _clienteRepository
				.FindBy(c => c.Email.ToUpper() == email.ToUpper()).Select(c => c.Codigo)
				.FirstOrDefault();
		}

		public List<ClienteDTO> ListarClientesCadastradosOntem()
		{
			var ontem = DateTime.Today.AddDays(-1).Date;
			return _clienteRepository.FindBy(c => c.DataCriacao.HasValue && c.DataCriacao.Value == ontem)
				.OrderByDescending(p => p.DataCriacao)
				.Select(c =>
					new ClienteDTO
					{
						Guid = c.Guid,
						Nome = c.Nome,
						Email = c.Email,
						CPF = c.CPF
					}
				)
				.ToList();
		}

		public void Cadastrar(Cliente cliente)
		{
			_clienteRepository.Add(cliente);
			_clienteRepository.Save();
		}
	}
}