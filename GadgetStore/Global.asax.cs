using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using GadgetStore.DAL;
using System.Data.Entity;

namespace GadgetStore
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			Database.SetInitializer<StoreContext>(new StoreInitializer());
		}
	}
}
