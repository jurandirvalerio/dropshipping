using Repositorios.Contratos;
using Repositorios.Implementacoes;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Repositorios.Packages
{
    public class Packages : IPackage
	{
		public void RegisterServices(Container container)
		{
			container.Register<IProdutoRepository, ProdutoRepository>();
		}
	}
}