using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Configuration
{
    public static class MigrateDatabase
    {
        public static IApplicationBuilder MigrateContext(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
                var db = serviceScope.ServiceProvider.GetService<SalesAppDataContext>();
                if(db != null)
                {
                    db.Database.Migrate();
                }
            }

            return app;
        }
    }
}
