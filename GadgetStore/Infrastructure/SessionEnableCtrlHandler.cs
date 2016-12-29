using System;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace GadgetStore
{
	public class SessionEnableCtrlHandler : HttpControllerHandler, IRequiresSessionState
	{
		public SessionEnableCtrlHandler(RouteData routeData) : base(routeData)
		{
		}
	}
}
