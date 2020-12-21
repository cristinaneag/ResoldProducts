using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResoldProducts.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Nume Categorie")]
        [Required, StringLength(150, MinimumLength = 3)]
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
