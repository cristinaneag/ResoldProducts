using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResoldProducts.Models;

namespace ResoldProducts.Data
{
    public class ResoldProductsContext : DbContext
    {
        public ResoldProductsContext (DbContextOptions<ResoldProductsContext> options)
            : base(options)
        {
        }

        public DbSet<ResoldProducts.Models.Product> Product { get; set; }

        public DbSet<ResoldProducts.Models.Seller> Seller { get; set; }

        public DbSet<ResoldProducts.Models.Category> Category { get; set; }
    }
}
