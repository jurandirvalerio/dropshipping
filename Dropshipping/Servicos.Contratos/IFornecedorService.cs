using System.Collections.Generic;
using DTOs;

namespace Servicos.Contratos
{
	public interface IFornecedorService
	{
		List<FornecedorDTO> Listar();

		FornecedorDTO Obter(int codigo);

		void Alterar(FornecedorDTO fornecedorDto);

		void Incluir(FornecedorDTO fornecedorDto);
	}
}
