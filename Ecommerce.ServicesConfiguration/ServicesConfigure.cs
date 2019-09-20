using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstraction.BLL;
using Ecommerce.Abstraction.Repositories;
using Ecommerce.BLL;
using Ecommerce.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ServicesConfiguration
{
    public class ServicesConfigure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}