using System.Collections.Generic;
using System.Linq;
using DTOs;
using Entidades;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class FornecedorMapper : IFornecedorMapper
	{
		public FornecedorDTO Map(Fornecedor fornecedor)
		{
			return new FornecedorDTO
			{
				Nome = fornecedor.Nome,
				DataCriacao = fornecedor.DataCriacao,
				Codigo = fornecedor.Codigo,
				Visivel = fornecedor.Visivel,
				DataAtualizacao = fornecedor.DataAtualizacao,
				SenhaApi = fornecedor.SenhaApi,
				UrlEndpointApi = fornecedor.UrlEndpointApi,
				UsuarioApi = fornecedor.UsuarioApi
			};
		}

		public Fornecedor Map(Fornecedor fornecedor, FornecedorDTO fornecedorDto)
		{
			fornecedor.Nome = fornecedorDto.Nome;
			fornecedor.DataCriacao = fornecedorDto.DataCriacao;
			fornecedor.Codigo = fornecedorDto.Codigo;
			fornecedor.Visivel = fornecedorDto.Visivel;
			fornecedor.DataAtualizacao = fornecedorDto.DataAtualizacao;
			fornecedor.SenhaApi = fornecedorDto.SenhaApi;
			fornecedor.UrlEndpointApi = fornecedorDto.UrlEndpointApi;
			fornecedor.UsuarioApi = fornecedorDto.UsuarioApi;

			return fornecedor;
		}

		public List<FornecedorDTO> Map(List<Fornecedor> fornecedorSet)
		{
			return fornecedorSet.Select(Map).ToList();
		}
	}
}