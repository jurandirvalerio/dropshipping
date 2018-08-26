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
		    container.Register<IFornecedorService, FornecedorService>();
			container.Register<IFornecedorRepository, FornecedorRepository>();
		    container.Register<IFornecedorMapper, FornecedorMapper>();
			container.Register<IApiFornecedorRepository, ApiFornecedorRepository>();
		    container.Register<IProdutoFornecedorRepository, ProdutoFornecedorRepository>();
		    container.Register<IProdutoFornecedorService, ProdutoFornecedorService>();
		    container.Register<IPedidoService, PedidoService>();
		    container.Register<IPedidoRepository, PedidoRepository>();
			container.Register<IPedidoMapper, PedidoMapper>();
		}
	}
}