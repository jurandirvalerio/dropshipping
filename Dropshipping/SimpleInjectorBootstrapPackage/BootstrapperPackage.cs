using Repositorios.Contratos;
using Repositorios.Implementacoes;
using Servicos.Contratos;
using Servicos.Implementacoes;
using SimpleInjector;

namespace SimpleInjectorBootstrapPackage
{
    public class BootstrapperPackage
    {
	    public static void RegisterServices(Container container)
	    {
			container.Register<IProdutoRepository, ProdutoRepository>();
		    container.Register<IProdutoService, ProdutoService>();
		    container.Register<IClienteRepository, ClienteRepository>();
		    container.Register<IClienteService, ClienteService>();
		    container.Register<IProdutoMapper, ProdutoMapper>();
		}
	}
}
