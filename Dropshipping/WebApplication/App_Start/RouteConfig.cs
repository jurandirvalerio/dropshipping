using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {controller = "vitrine", action = "Index", id = UrlParameter.Optional},
				null,
				new[] { "MWebApplication.Areas.Loja.Controllers" }
			).DataTokens.Add("area", "Loja");
		}
	}
}
