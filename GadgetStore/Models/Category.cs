using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.Entity;

namespace GadgetStore.Models {
    [Table("category")]
    public class Category {
		[Key]
		[Column("id_category")]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Gadget> Gadgets {get; set;}
    }
}