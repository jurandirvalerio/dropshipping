using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Loja.Infrastructure.Mappers;
using Loja.Infrastructure.ModelBinders;

namespace Loja
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			SimpleInjectorConfig.InicializarSimpleInjector();
			AutoMapperConfig.RegisterMappings();
			ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
		}
	}
}