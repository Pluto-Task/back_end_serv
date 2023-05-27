using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired();

        builder.Property(x => x.Password).IsRequired();

        builder.Property(x => x.Email).IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Phone).IsRequired();

        builder.Property(x => x.DateCreated).IsRequired();

        builder.Property(x => x.Rating).IsRequired();

        builder.Property(x => x.NumberOfEventsTookPart).IsRequired();

        builder.Property(x => x.NumberOfEventsCreated).IsRequired();

        builder.HasMany(p => p.Skills).WithOne(p => p.User).HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}