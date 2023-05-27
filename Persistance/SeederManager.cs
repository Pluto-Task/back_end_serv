using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Seeder;

namespace Persistence
{
    public static class SeederManager
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            DatabaseSeeder.SeedAsync(serviceProvider).Wait();
            return app;
        }
    }
}