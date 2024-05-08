using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Persistence.Repositories;

namespace MyEshop_Clean.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static void ConfigurePersistenceRegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EshopContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EshopConnectionString"));
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryToProductRepository, CategoryToProductRepository>();
        }
    }
}
