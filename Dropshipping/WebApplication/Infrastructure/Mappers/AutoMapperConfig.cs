using AutoMapper;

namespace WebApplication.Infrastructure.Mappers
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
		}
	}
}