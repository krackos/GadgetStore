using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GadgetStore
{
	public class TempOrdersController : ApiController
	{
		public List<Cart> GetTempOrders() {
			List<Cart> cartItems = null;

			if (HttpContext.Current.Session["Cart"] != null) {
				cartItems = (List<Cart>)HttpContext.Current.Session["Cart"];
			}

			return cartItems;
		}

		[HttpPost]
		public HttpResponseMessage SaveOrder(List<Cart> cartItems) {
			if (!ModelState.IsValid)
				return new HttpResponseMessage(HttpStatusCode.BadRequest);

			HttpContext.Current.Session["Cart"] = cartItems;

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
