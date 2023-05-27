using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Seeder;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        await Seed.UsersSeeder(context);
        // await Seed.Name(context);
        // await Seed.Name(context);
        //use partial class Seed
    }
}