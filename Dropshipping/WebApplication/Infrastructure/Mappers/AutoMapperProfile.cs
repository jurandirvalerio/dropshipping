﻿using AutoMapper;
using DTOs;
using Entidades;
using Loja.Areas.Administracao.Models.Fornecedores;
using Loja.Models.Login;
using Loja.Models.Produtos;

namespace Loja.Infrastructure.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ProdutoDTO, ProdutoViewModel>().ForMember(s => s.UrlImagemSet, c => c.MapFrom(m => m.UrlSet));
			CreateMap<RegistroViewModel, Cliente>();
			CreateMap<FornecedorDTO, FornecedorViewModel>();
		}
	}
}