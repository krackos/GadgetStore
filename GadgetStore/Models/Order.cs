using System.Collections.Generic;
using System;
using GadgetStore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GadgetStore.Models;

namespace GadgetStore {
	[Table("order")]
    public class Order {
        public Order() {
            Gadgets = new List<Gadget>();
        }

		[Key]
		[Column("id_order")]
        public int OrderID { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public List<Gadget> Gadgets { get; set; }
    }
}