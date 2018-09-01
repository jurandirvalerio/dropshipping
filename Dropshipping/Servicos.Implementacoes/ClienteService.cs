using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		private readonly IClienteHistoricoRepository _clienteHistoricoRepository;

		public ClienteService(IClienteRepository clienteRepository, IClienteHistoricoRepository clienteHistoricoRepository)
		{
			_clienteRepository = clienteRepository;
			_clienteHistoricoRepository = clienteHistoricoRepository;
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
			return _clienteRepository
				.FindBy(c => c.DataCriacao.HasValue && DbFunctions.TruncateTime(c.DataCriacao.Value) == ontem)
				.OrderByDescending(p => p.DataCriacao)
				.Select(c =>
					new ClienteDTO
					{
						Guid = c.Guid,
						Nome = c.Nome,
						Email = c.Email,
						CPF = c.CPF,
						Codigo = c.Codigo,
						DataCriacao = c.DataCriacao,
						DataAtualizacao = c.DataAtualizacao
					}
				)
				.ToList();
		}

		public bool JaEnviouDadosAoBIHoje()
		{
			return _clienteHistoricoRepository.FindBy(h => DbFunctions.TruncateTime(h.DataCriacao) == DateTime.Today.Date).Any();
		}

		public void Cadastrar(Cliente cliente)
		{
			_clienteRepository.Add(cliente);
			_clienteRepository.Save();
		}

		public void CadastrarHistorico(ClienteHistorico clienteHistorico)
		{
			_clienteHistoricoRepository.Add(clienteHistorico);
			_clienteHistoricoRepository.Save();
		}
	}
}