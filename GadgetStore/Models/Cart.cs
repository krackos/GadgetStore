using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetStore
{
	[Table("cart")]
	public class Cart
	{
		[Key]
		[Column("id_cart")]
		public int Count { get; set; }
		public int GadgetID { get; set; }
		public decimal Price { get; set; }
		public string Name { get; set; }
		public int CategoryID { get; set; }
	}
}
