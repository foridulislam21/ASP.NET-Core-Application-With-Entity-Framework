using System.Collections.Generic;
using Ecommerce.Abstraction.Repositories.Base;
using Ecommerce.Models;

namespace Ecommerce.Abstraction.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetByName(string search);
    }
}