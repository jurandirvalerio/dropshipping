using AutoMapper;

namespace Loja.Infrastructure.Mappers
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
		}
	}
}