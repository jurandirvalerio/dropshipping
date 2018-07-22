using System.Web.Mvc;
using Repositorios.Contratos;
using Repositorios.Implementacoes;
using Servicos.Contratos;
using Servicos.Implementacoes;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace WebApplication
{
	public static class SimpleInjectorConfig
	{
		public  static void InicializarSimpleInjector()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			container.Register<IProdutoRepository, ProdutoRepository>();
			container.Register<IProdutoService, ProdutoService>();

			//container.RegisterWebApiControllers(GlobalConfiguration.Configuration); //web api
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			//GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container); //web api
		}
	}
}