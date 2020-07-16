using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstructions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Database.Database;
using Microsoft.EntityFrameworkCore;
using Ecommerce.BLL.Abstructions;
using Ecommerce.BLL;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ecommerce.Configuration
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminManager, AdminManager>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<DbContext, EcommerceDbContext>();
            
        }
    }
}
