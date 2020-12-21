using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResoldProducts.Data;
using ResoldProducts.Models;

namespace ResoldProducts.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly ResoldProducts.Data.ResoldProductsContext _context;

        public EditModel(ResoldProducts.Data.ResoldProductsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context
                .Product
                .Include(b => b.ProductCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Product);

            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null) { return NotFound(); }
            var productToUpdate = await _context.Product
                .Include(i => i.Seller)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null) { return NotFound(); }
            if (await TryUpdateModelAsync<Product>
                (productToUpdate,
                "Product",
                i => i.Denumire,
                i => i.Descriere,
                i => i.Pret,
                i => i.DataAdaugarii,
                i => i.SellerID)
                )
            {
                UpdateProductCategories(
                    _context,
                    selectedCategories,
                    productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateProductCategories pentru a aplica informatiile din checkboxuri la entitatea Products care 
            //este editata

            UpdateProductCategories(_context, selectedCategories, productToUpdate);

            PopulateAssignedCategoryData(_context, productToUpdate);

            return Page();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
