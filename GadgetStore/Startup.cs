using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GadgetStore.Startup))]

namespace GadgetStore
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app) {
			ConfigureStoreAuthentication(app);
		}
	}
}
