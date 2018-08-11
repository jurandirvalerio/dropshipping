using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IFornecedorMapper
	{
		FornecedorDTO Map(Fornecedor fornecedor);
		List<FornecedorDTO> Map(List<Fornecedor> fornecedorSet);
		Fornecedor Map(Fornecedor fornecedor, FornecedorDTO fornecedorDto);
	}
}