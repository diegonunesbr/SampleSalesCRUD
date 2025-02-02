using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Configuration
{
    public static class ConfigureDataContext
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesAppDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SalesApp"));
            });

            return services;
        }
    }
}
