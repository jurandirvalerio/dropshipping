using Servicos.Contratos;
using Servicos.Implementacoes;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Servicos.Packages
{
    public class Packages : IPackage
	{
		public void RegisterServices(Container container)
		{
			container.Register<IProdutoService, ProdutoService>();
		}
	}
}