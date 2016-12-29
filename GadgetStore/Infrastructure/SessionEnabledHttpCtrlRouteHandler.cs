using System;
using System.Web.Http.WebHost;

namespace GadgetStore
{
	public class SessionEnabledHttpCtrlRouteHandler : HttpControllerRouteHandler
	{
		protected override System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
		{
			return new SessionEnableCtrlHandler(requestContext.RouteData);
		}
	}
}
