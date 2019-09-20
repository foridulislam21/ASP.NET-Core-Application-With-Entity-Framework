using Ecommerce.Abstraction.BLL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstraction.Repositories;
using Ecommerce.BLL;
using Ecommerce.DatabaseContext;
using Ecommerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Configurations
{
    public class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<DbContext, EcommerceDbContext>();
        }
    }
}