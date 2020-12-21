using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResoldProducts.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string Denumire{ get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        public string Descriere{ get; set; }
        public decimal Pret{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAdaugarii { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        [Display(Name = "Categorii Produs")]
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public string GetProdSeller
        {
            get
            {
                return Denumire + ", pret: "+Pret;
            }
        }

    }
}
