using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Abstraction.Repositories;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        private EcommerceDbContext _db;

        public CustomerRepository(DbContext db) : base(db)
        {
            _db = db as EcommerceDbContext;
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            return _db.Customers.Where(c => c.Name.StartsWith(name));
        }

        public override ICollection<Customer> GetAll()
        {
            return _db.Customers.OrderBy(c => c.Name).ToList();
        }
    }
}