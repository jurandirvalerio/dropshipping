﻿using AutoMapper;
using DTOs;
using WebApplication.Models;

namespace WebApplication.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ProdutoDTO, ProdutoViewModel>().ForMember(s => s.UrlImagemSet, c => c.MapFrom(m => m.UrlSet));
		}
	}
}