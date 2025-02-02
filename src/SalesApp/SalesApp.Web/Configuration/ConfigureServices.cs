using SalesApp.Infrastructure.Configuration;

namespace SalesApp.Web.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataContext(configuration);


            return services;
        }
    }
}
