using AutoMapper;
using Entidades;
using WebApplication.Areas.Loja.Models;

namespace WebApplication.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Produto, ProdutoViewModel>().ForMember(s => s.UrlImagemDetalheSet, c => c.MapFrom(m => m.UrlImagemDetalheSet));
			CreateMap<UrlImagem, UrlImagemViewModel>();
		}
	}
}