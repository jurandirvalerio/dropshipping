using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(FornecedorAPI.Startup))]

namespace FornecedorAPI
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();

			// configurando rotas
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{guid}",
				defaults: new { guid = RouteParameter.Optional }
			);

			// ativando cors
			app.UseCors(CorsOptions.AllowAll);

			AtivandoAccessToken(app);

			// ativando configuração WebApi
			app.UseWebApi(config);
		}

		private void AtivandoAccessToken(IAppBuilder app)
		{
			var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
				Provider = new ProviderDeTokensDeAcesso()
			};

			app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}