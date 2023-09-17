using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Repositories.InventoryRepo;
using Repositories.OrderRepo;
using Repositories.ProductRepo;
using Repositories.UserRepo;
using System.Reflection;

namespace Repositories
{
    public static class DependencyInjection
    {   
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddAllGenericTypes
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
            services.AddScoped<IBaseRepository<Inventory>, BaseRepository<Inventory>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();

            return services;
        }
    }
}
