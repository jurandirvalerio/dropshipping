using AutoMapper;
using DTOs;
using Entidades;
using WebApplication.Models.Login;
using WebApplication.Models.Produtos;

namespace WebApplication.Infrastructure.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ProdutoDTO, ProdutoViewModel>().ForMember(s => s.UrlImagemSet, c => c.MapFrom(m => m.UrlSet));
			CreateMap<RegistroViewModel, Cliente>();
		}
	}
}