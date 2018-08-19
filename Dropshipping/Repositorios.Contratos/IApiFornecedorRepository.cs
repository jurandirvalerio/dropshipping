using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Entidades;

namespace Repositorios.Contratos
{
	public interface IApiFornecedorRepository
	{
		Task<List<ProdutoFornecedorDTO>> ListarProdutos(Fornecedor fornecedor);
		void Subscrever(ProdutoFornecedor produtoFornecedorDto);
		void CancelarSubscricao(ProdutoFornecedor produtoFornecedorDto);
	}
}