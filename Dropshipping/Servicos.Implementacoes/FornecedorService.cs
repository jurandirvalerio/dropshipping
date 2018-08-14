using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Entidades;
using Repositorios.Contratos;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class FornecedorService : IFornecedorService
	{
		private readonly IFornecedorRepository _fornecedorRepository;
		private readonly IApiFornecedorRepository _apiFornecedorRepository;
		private readonly IFornecedorMapper _fornecedorMapper;

		public FornecedorService(IFornecedorRepository fornecedorRepository, IFornecedorMapper fornecedorMapper, IApiFornecedorRepository apiFornecedorRepository)
		{
			_fornecedorRepository = fornecedorRepository;
			_fornecedorMapper = fornecedorMapper;
			_apiFornecedorRepository = apiFornecedorRepository;
		}

		public List<FornecedorDTO> Listar()
		{
			return _fornecedorMapper.Map(QueryFornecedoresVisiveis().ToList());
		}

		private IQueryable<Fornecedor> QueryFornecedoresVisiveis()
		{
			return _fornecedorRepository.GetAll()
				.Where(p => p.Visivel)
				.Include(p => p.ProdutoSet);
		}

		public FornecedorDTO Obter(int codigo)
		{
			return _fornecedorMapper.Map(_fornecedorRepository.FindBy(f => f.Codigo == codigo).FirstOrDefault());
		}

		public void Alterar(FornecedorDTO fornecedorDto)
		{
			var fornecedor = _fornecedorRepository.FindBy(f => f.Codigo == fornecedorDto.Codigo).FirstOrDefault();
			_fornecedorRepository.Edit(_fornecedorMapper.Map(fornecedor, fornecedorDto));
		}

		public void Incluir(FornecedorDTO fornecedorDto)
		{
			var fornecedor = new Fornecedor();
			fornecedor = _fornecedorMapper.Map(fornecedor, fornecedorDto);
			_fornecedorRepository.Add(fornecedor);
		}

		public List<ProdutoFornecedorDTO> ListarProdutos(int codigoFornecedor)
		{
			var fornecedor = _fornecedorRepository.FindBy(f => f.Codigo == codigoFornecedor).FirstOrDefault();
			return _apiFornecedorRepository.ListarProdutos(fornecedor).Result;
		}


	}
}