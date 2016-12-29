using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GadgetStore
{
	public partial class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
		public static string PublicClientId { get; private set; }
		public void ConfigureStoreAuthentication(IAppBuilder app) {
			app.CreatePerOwinContext(StoreContext.Create);
			app.CreatePerOwinContext<AppStoreUserManager>(AppStoreUserManager.Create);

			PublicClientId = "self";
			OAuthOptions = new OAuthAuthorizationServerOptions() { 
				TokenEndpointPath = new PathString("/Token"),
				Provider = new ApplicationOAuthProvider(PublicClientId),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
				AllowInsecureHttp = true
			};

			app.UseOAuthBearerTokens(OAuthOptions);
		}
	}
}
