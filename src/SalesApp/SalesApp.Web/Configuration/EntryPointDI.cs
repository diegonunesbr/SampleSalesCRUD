using SalesApp.Application.Configuration;
using SalesApp.Infrastructure.Configuration;

namespace SalesApp.Web.Configuration
{
    public static class EntryPointDI
    {
        public static IServiceCollection AddEntryPointServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices(configuration);

            return services;
        }
    }
}
