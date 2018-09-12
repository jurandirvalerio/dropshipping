using System;
using System.Web.Http;
using Hangfire;
using LojaAPI.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(LojaAPI.Startup))]
namespace LojaAPI
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();

			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{guid}",
				defaults: new { guid = RouteParameter.Optional }
			);

			app.UseCors(CorsOptions.AllowAll);
			AtivandoAccessToken(app);

			Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("DadosGerenciais");
			Hangfire.GlobalConfiguration.Configuration.UseActivator(new SimpleInjectorJobActivator(SimpleInjectorWebApiInitializer.Container));
			Hangfire.GlobalJobFilters.Filters.Add(new SimpleInjectorAsyncScopeFilterAttribute(SimpleInjectorWebApiInitializer.Container));
			app.UseHangfireDashboard("/dashboard", new DashboardOptions()
			{
				Authorization = new[] { new HangFireAuthorizationFilter() }
			});
			app.UseHangfireServer();

		}

		private static void AtivandoAccessToken(IAppBuilder app)
		{
			var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/api/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
				Provider = new ProviderDeTokensDeAcesso()
			};

			app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}