using AutoMapper;
using Entidades;
using WebApplication.Areas.Loja.Models;

namespace WebApplication.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Produto, ProdutoViewModel>();
		}
	}
}