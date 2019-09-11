using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CustomerRepository
    {
        private EcommerceDbContext _db;

        public CustomerRepository()
        {
            _db = new EcommerceDbContext();
        }

        public bool Add(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges() > 0;
        }

        public Customer GetById(int? id)
        {
            return _db.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return _db.Customers
                .OrderBy(c => c.Name)
                .ToList();
        }

        public bool Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public bool Remove(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Deleted;
            return _db.SaveChanges() > 0;
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            return _db.Customers.Where(c => c.Name.StartsWith(name));
        }
    }
}