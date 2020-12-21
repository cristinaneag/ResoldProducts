using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResoldProducts.Data;
using ResoldProducts.Models;

namespace ResoldProducts.Pages.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly ResoldProducts.Data.ResoldProductsContext _context;

        public IndexModel(ResoldProducts.Data.ResoldProductsContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; }

        public async Task OnGetAsync()
        {
            ProductCategory = await _context.ProductCategory
                .Include(p => p.Category)
                .Include(p => p.Product).ToListAsync();
        }
    }
}
