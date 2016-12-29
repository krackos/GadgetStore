using GadgetStore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using GadgetStore.Models;

namespace Store.Controllers
{
    public class CategoriesController : ApiController
    {
		private StoreContext db = new StoreContext();

		// GET: api/Categories
		public IQueryable<Category> GetCategories() {
			return db.Categories;
		}

		//Get: api/Categories/5
		[ResponseType(typeof(Category))]
		public async Task<IHttpActionResult> GetCategory(int id) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			Category category = await db.Categories.FindAsync(id);

			if (category == null)
				return NotFound();

			return Ok(category);
		
		}

		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutCategory(int id, Category category) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (id != category.CategoryID)
				return BadRequest();

			db.Entry(category).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (!CategoryExists(id))
					return NotFound();
				else
					throw;
						
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		//POST: api/Categories
		[ResponseType(typeof(Category))]
		public async Task<IHttpActionResult> PostCategory(Category category)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			db.Categories.Add(category);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
		}

		//Delete: api/Categories/5
		[ResponseType(typeof(Category))]
		public async Task<IHttpActionResult> DeleteCategory(int id) {
			Category category = await db.Categories.FindAsync(id);
			if (category == null)
				return NotFound();

			db.Categories.Remove(category);
			await db.SaveChangesAsync();

			return Ok(category);
		}

		protected override void Dispose(bool disposing) {
			if (disposing)
				db.Dispose();

			base.Dispose(disposing);
		}

		private bool CategoryExists(int id) {
			return db.Categories.Count(g => g.CategoryID == id) > 0;
		}
    }
}
