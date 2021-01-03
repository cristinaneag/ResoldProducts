using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResoldProducts.Models
{
    public class Seller
    {
        public int ID { get; set; }

        [Display(Name = "Nume Vanzator")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage ="Trebuie sa fie de forma Nume Prenume")
         , Required, StringLength(50, MinimumLength = 3)]
        public string SellerName { get; set; }

        [RegularExpression(
            @"^(([^<> ()[\]\.,;:\s@\']+(\.[^<>()[\]\.,;:\s@\']+)*)|(\'.+\'))@(([^<>()[\]\.,;:\s@\']+\.)+[^<>()[\]\.,;:\s@\']{2,})$"
            , ErrorMessage = "Adresa de email trebuie sa fie valida."), Required]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage ="Nr. de telefon trebuie sa contina doar 10 cifre"),Required]
        public string Telefon { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+((-|\s)[A-Z][a-z]+)?,[A-Z][a-z]+$", ErrorMessage ="Locatia trebuie sa fie de forma Localitate,Judet"), Required]
        public string Locatie { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
