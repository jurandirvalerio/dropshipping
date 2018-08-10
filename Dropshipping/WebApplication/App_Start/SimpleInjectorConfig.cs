using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjectorBootstrapPackage;

namespace Loja
{
	public static class SimpleInjectorConfig
	{
		public  static void InicializarSimpleInjector()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			BootstrapperPackage.RegisterServices(container);

			//container.RegisterWebApiControllers(GlobalConfiguration.Configuration); //web api
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			//GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container); //web api
		}
	}
}