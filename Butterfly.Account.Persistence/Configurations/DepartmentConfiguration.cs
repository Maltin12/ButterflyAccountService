using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
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
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.ToTable("Departments");
        }
    }
}