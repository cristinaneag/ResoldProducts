using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResoldProducts.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        [Display(Name = "Produs")]
        public Product Product { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Categorie")]
        public Category Category { get; set; }
    }
}
