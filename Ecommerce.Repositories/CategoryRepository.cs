using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CategoryRepository
    {
        private EcommerceDbContext db;

        public CategoryRepository()
        {
            db = new EcommerceDbContext();
        }
        public bool Add(Category category)
        {
            db.Categories.Add(category);

            return db.SaveChanges() > 0;
        }


        public bool Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public ICollection<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void LoadProducts(Category category)
        {
            db.Entry(category)
                .Collection(c=>c.Products)
                .Query()
                .Where(c=>c.IsActive)
                .Load();
         
        }
    }
}
