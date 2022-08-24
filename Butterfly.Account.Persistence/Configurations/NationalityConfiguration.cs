using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{
    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
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

            builder.ToTable("Nationalities");
        }
    }
}
