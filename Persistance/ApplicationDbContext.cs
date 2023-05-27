using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserEvent> UserEvents { get; set; }

    public DbSet<UserEventTable> UserEventsTable { get; set; }

    public DbSet<EventSkills> EventSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
}

