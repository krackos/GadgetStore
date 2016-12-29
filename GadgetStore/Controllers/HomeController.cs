using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GadgetStore.Models;
using System.Data.Entity;

namespace GadgetStore.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ViewOrder(int id) {
			using (var context = new StoreContext()) {
				var order = context.Orders.Find(id);
				var gadgetOrders = context.GadgetOrders.Include(h => h.Gadget).Where(go => go.OrderID == id);
				foreach (GadgetOrder gadgetOrder in gadgetOrders)
				{
					order.Gadgets.Add(gadgetOrder.Gadget);
				}
				return View(order);
			}
		}
	}
}
