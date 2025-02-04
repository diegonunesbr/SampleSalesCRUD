using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.Application.Interfaces;
using SalesApp.Infrastructure.DataContext;
using SalesApp.Infrastructure.Repositories;

namespace SalesApp.Infrastructure.Configuration
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesAppDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SalesApp"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
