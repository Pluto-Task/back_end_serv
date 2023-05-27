using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class EventSkillsConfiguration : IEntityTypeConfiguration<EventSkills>
{
    public void Configure(EntityTypeBuilder<EventSkills> builder)
    {
        builder.ToTable(nameof(EventSkills));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.UserEventId).IsRequired();

        builder.Property(x => x.SkillId).IsRequired();
        builder.Property(x => x.Exp).IsRequired();
    }
}