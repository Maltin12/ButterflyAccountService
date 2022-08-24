using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{
    public class CountryConfiguration :IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)

        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasDefaultValue(true)
                .IsRequired();

            builder.ToTable("Countries");

        }
    }
}