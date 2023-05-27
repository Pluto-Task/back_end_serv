using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Persistence.Configuration
{
    internal sealed class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.ToTable(nameof(UserEvent));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x=>x.MaxPeople).IsRequired();
            builder.Property(x=>x.CurrentPeople).IsRequired();

            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.Build).IsRequired();

            builder.Property(x => x.Coordinates).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.StartDate).IsRequired();

            builder.Property(x => x.EndDate).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(p => p.EventSkills).WithOne(p => p.UserEvent).HasForeignKey(c => c.UserEventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
