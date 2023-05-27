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

            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.Build).IsRequired();

            builder.Property(x => x.Coordinates).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.StartDate).IsRequired();

            builder.Property(x => x.EndDate).IsRequired();

            builder.Property(x => x.Skills).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder
                .Property(u => u.Skills)
                .HasConversion(
                    skills => JsonConvert.SerializeObject(skills),
                    json => JsonConvert.DeserializeObject<Dictionary<string, float>>(json)
                );
        }
    }
}
