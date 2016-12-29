using System;
using System.Data.Entity;
using GadgetStore;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using GadgetStore.Models;

namespace GadgetStore.DAL
{
	public class CategoryConfiguration : EntityTypeConfiguration<Category>
	{
		public CategoryConfiguration()
		{
			HasKey(c => c.CategoryID);
			Property(c => c.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		}
	}
}
