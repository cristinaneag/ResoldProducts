using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResoldProducts.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string SellerName { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Locatie { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
