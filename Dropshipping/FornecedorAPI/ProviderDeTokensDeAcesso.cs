using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace FornecedorAPI
{
	public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			if (!CredenciaisValidas(context))
			{
				context.SetError("invalid_grant", "Identificação inválida.");
				return;
			}

			context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
		}

		private static bool CredenciaisValidas(OAuthGrantResourceOwnerCredentialsContext context)
		{
			return context?.UserName == "chefsuser" && context.Password == "chefspassword";
		}
	}
}