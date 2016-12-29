using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GadgetStore
{
	public class AppStoreUser : IdentityUser
	{
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
	}
}
