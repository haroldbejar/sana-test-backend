using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Dtos.CustomerDto;
using Appllication.Services.Dtos.InventoryDto;
using Appllication.Services.Dtos.OrderDto;
using Appllication.Services.Dtos.ProductDto;
using Appllication.Services.Services.CategoryService;
using Appllication.Services.Services.CustomerService;
using Appllication.Services.Services.InventoryService;
using Appllication.Services.Services.OrderService;
using Appllication.Services.Services.ProductService;
using Appllication.Services.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Appllication.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICategoryMapper, CategoryMapper>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInventoryMapper, InventoryMapper>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
