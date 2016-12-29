using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GadgetStore
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapHttpRoute(
				name: "SessionRoute",
				routeTemplate: "api/sessions/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			).RouteHandler = new SessionEnabledHttpCtrlRouteHandler();

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
