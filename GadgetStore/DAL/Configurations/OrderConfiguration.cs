using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using GadgetStore;

namespace GadgetStore.DAL
{
	public class OrderConfiguration : EntityTypeConfiguration<Order>
	{
		public OrderConfiguration()
		{
			Ignore(o => o.Gadgets);
		}
	}
}
