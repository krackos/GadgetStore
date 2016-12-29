using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GadgetStore
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		private readonly string _publicClientId;

		public ApplicationOAuthProvider(string  publicClientId)
		{
			if (publicClientId == null) {
				throw new ArgumentNullException("publicClientId");
			}
			_publicClientId = publicClientId;
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
			var userManager = context.OwinContext.GetUserManager<AppStoreUserManager>();

			AppStoreUser user = await userManager.FindAsync(context.UserName, context.Password);

			if (user == null) {
				context.SetError("invalid_grant", "Invalid username or password.");
				return;
			}

			ClaimsIdentity oAuthIdentity = await userManager.GenerateUserIdentityAsync(user, OAuthDefaults.AuthenticationType);
			AuthenticationProperties properties = new AuthenticationProperties();
			AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
			context.Validated(ticket);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			if (context.ClientId == null)
				context.Validated();

			return Task.FromResult<object>(null);
		}
	}
}
