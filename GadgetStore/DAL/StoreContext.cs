using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GadgetStore.DAL;
using GadgetStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GadgetStore
{
	public class StoreContext : IdentityDbContext<AppStoreUser>
	{
		public StoreContext() :base("name=GadgetStore", throwIfV1Schema: false){}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
			modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
			modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

			modelBuilder.Configurations.Add(new AppStoreUserConfiguration());
			modelBuilder.Configurations.Add(new CategoryConfiguration());
			modelBuilder.Configurations.Add(new OrderConfiguration());
		}

		public static StoreContext Create() {
			return new StoreContext();
		}

		public DbSet<Gadget> Gadgets { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<GadgetOrder> GadgetOrders { get; set; }
	}
}
