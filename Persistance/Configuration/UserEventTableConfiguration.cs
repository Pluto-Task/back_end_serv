using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Persistence.Configuration
{
    internal class UserEventTableConfiguration : IEntityTypeConfiguration<UserEventTable>
    {
        public void Configure(EntityTypeBuilder<UserEventTable> builder)
        {
            builder.ToTable(nameof(UserEventTable));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserEventId).IsRequired();

            builder.Property(x => x.UserId).IsRequired();
        }
    }
}