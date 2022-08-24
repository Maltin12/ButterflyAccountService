using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{

    public class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
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

            builder.Property(x => x.CountryId)
                .HasColumnName("CountryId")
                .IsRequired();

            builder.Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .IsRequired();


            Relationships(builder);

            builder.ToTable("Cities");

        }

        private void Relationships(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}