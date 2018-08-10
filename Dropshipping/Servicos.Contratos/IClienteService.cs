using Entidades;

namespace Servicos.Contratos
{
	public interface IClienteService
	{
		void Cadastrar(Cliente cliente);
		string ObterNomeCliente(string email);
	}
}