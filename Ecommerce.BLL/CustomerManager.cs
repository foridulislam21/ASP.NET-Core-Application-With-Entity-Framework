using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Abstraction.BLL;
using Ecommerce.Abstraction.Repositories;
using Ecommerce.BLL.Base;
using Ecommerce.Models;

namespace Ecommerce.BLL
{
    public class CustomerManager : Manager<Customer>, ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetByName(string search)
        {
            return _customerRepository.GetByName(search);
        }
    }
}