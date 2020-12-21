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
        public string Denumire{ get; set; }
        public string Descriere{ get; set; }
        public decimal Pret{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAdaugarii { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
