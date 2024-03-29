﻿using System.Collections.Generic;

namespace Ecommerce.Abstraction.BLL.Base
{
    public interface IManager<T> where T : class
    {
        bool Add(T entity);

        bool Remove(T entity);

        bool Update(T entity);

        ICollection<T> GetAll();

        T GetById(int id);
    }
}