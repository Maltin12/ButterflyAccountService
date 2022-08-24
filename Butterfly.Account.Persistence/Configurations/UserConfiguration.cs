using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.BirthDate)
                .HasColumnName("BirthDate")
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .IsRequired();

            builder.Property(x => x.GenderId)
                .HasColumnName("GenderId")
                .IsRequired();

            builder.Property(x => x.DepartmentId)
                .HasColumnName("DepartmentId")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            RelationShips(builder);

            builder.ToTable("Users");
        }
        private void RelationShips(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Gender)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}