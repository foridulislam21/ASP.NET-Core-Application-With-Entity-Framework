using System.Collections.Generic;
using Ecommerce.Abstraction.BLL.Base;
using Ecommerce.Models;

namespace Ecommerce.Abstraction.BLL
{
    public interface ICustomerManager : IManager<Customer>
    {
        IEnumerable<Customer> GetByName(string search);
    }
}