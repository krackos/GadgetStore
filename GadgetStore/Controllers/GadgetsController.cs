using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net;
using System.Net.Http;
using GadgetStore;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using GadgetStore.Models;

namespace Store.Controllers
{
    public class GadgetsController : ApiController
    {
		private StoreContext db = new StoreContext();

		//GET : api/Gadgets
		public IQueryable<Gadget> GetGadgets() {
			return db.Gadgets;
		}

		//Get: api(Gadgets/5
		[ResponseType(typeof(Gadget))]
		public async Task<IHttpActionResult> GetGadget(int id) {
			Gadget gadget = await db.Gadgets.FindAsync(id);
			if (gadget == null)
				return NotFound();

			return Ok(gadget);
		}

		//Put: api/Gadgets/5
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutGadget(int id, Gadget gadget) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (id != gadget.CategoryID)
				return BadRequest();

			db.Entry(gadget).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (!GadgetExists(id))
					return NotFound();
				else
				    throw;
			}
			return StatusCode(HttpStatusCode.NoContent);
		}

		//Post api/Gadgets
		[ResponseType(typeof(Gadget))]
		public async Task<IHttpActionResult> PostGadget(Gadget gadget) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			db.Gadgets.Add(gadget);

			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = gadget.CategoryID}, gadget);
		}

		//Delete api/Gadget/5
		[ResponseType(typeof(Gadget))]
		public async Task<IHttpActionResult> DeleteGadget(int id) {
			Gadget gadget = await db.Gadgets.FindAsync(id);

			if (gadget == null)
				return NotFound();

			db.Gadgets.Remove(gadget);
			await db.SaveChangesAsync();

			return Ok(gadget);
		 
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				db.Dispose();

			base.Dispose(disposing);
		}

		private bool GadgetExists(int id)
		{
			return db.Gadgets.Count(g => g.CategoryID == id) > 0;
		}
    }
}
