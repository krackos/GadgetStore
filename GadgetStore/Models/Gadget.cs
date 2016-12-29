using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetStore.Models {
	[Table("gadget")]
    public class Gadget
    {
		[Key]
		[Column("id_gadget")]
        public int GadgetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}