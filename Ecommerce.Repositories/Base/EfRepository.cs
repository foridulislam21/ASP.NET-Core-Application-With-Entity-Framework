using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories.Base
{
    public class EfRepository<T> where T : class
    {
        private readonly DbContext _db;

        public EfRepository(DbContext db)
        {
            _db = db;
        }

        public virtual bool Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            _db.Set<T>().Update(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }
    }
}