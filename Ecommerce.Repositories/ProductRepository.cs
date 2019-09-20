using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductRepository : EfRepository<Product>
    {
        private EcommerceDbContext _db;

        public ProductRepository(DbContext db) : base(db)
        {
            _db = db as EcommerceDbContext;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }
    }
}