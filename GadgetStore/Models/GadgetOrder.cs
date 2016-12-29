using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GadgetStore;

namespace GadgetStore.Models {
	[Table("gadgetorder")]
    public class GadgetOrder {
		[Key]
		[Column("id_gadgetorder")]
        public int GadgetOrderID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int GadgetID { get; set; }
        public Gadget Gadget { get; set; }
    } 
}