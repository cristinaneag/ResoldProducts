using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResoldProducts.Data;
using ResoldProducts.Models;

namespace ResoldProducts.Pages.Sellers
{
    public class DetailsModel : PageModel
    {
        private readonly ResoldProducts.Data.ResoldProductsContext _context;

        public DetailsModel(ResoldProducts.Data.ResoldProductsContext context)
        {
            _context = context;
        }

        public Seller Seller { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = await _context.Seller.FirstOrDefaultAsync(m => m.ID == id);

            if (Seller == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
