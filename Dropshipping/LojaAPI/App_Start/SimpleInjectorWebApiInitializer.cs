using SimpleInjector.Integration.Web;

[assembly: WebActivator.PostApplicationStartMethod(typeof(LojaAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace LojaAPI.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {

	    public static Container Container;

	    /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
	        Container = new Container();
	        Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			InitializeContainer(Container);
	        Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
	        Container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }
     
        private static void InitializeContainer(Container container)
        {
			SimpleInjectorBootstrapPackage.BootstrapperPackage.RegisterServices(container);
		}
    }
}