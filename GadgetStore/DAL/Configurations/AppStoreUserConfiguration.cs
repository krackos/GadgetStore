using System;
using System.Data.Entity.ModelConfiguration;

namespace GadgetStore
{
	public class AppStoreUserConfiguration : EntityTypeConfiguration<AppStoreUser>
	{
		public AppStoreUserConfiguration()
		{
			ToTable("User");
		}
	}
}
