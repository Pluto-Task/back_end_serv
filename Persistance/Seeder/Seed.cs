using Domain.Entity;

namespace Persistence.Seeder;

internal static partial class Seed
{
    public static async Task UsersSeeder(ApplicationDbContext context)
    {
        if (!context.Users.Any())
        {
            var user = new User("admin@pluto.com",
                "AOF7RulQUzN9zhkab8pb9PxywbLDd23RBhCyuCqHeZN+a90dIibzduJ2+YkOKAdaPw==","admin");

            await context.Users.AddRangeAsync(user);
            await context.SaveChangesAsync();
        }
    }
}