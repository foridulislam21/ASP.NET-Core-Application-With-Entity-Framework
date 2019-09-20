using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    internal class OrderRepository : EfRepository<Order>
    {
        private readonly EcommerceDbContext _db;

        public OrderRepository(DbContext db) : base(db)
        {
            _db = db as EcommerceDbContext;
        }
    }
}