using AutoMapper;

namespace WebApplication.Mappers
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
		}
	}
}