using System.Linq;
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

		public void Cadastrar(Cliente cliente)
		{
			_clienteRepository.Add(cliente);
			_clienteRepository.Save();
		}
	}
}