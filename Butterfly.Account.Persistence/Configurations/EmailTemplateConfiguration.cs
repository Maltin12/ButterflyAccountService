using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Butterfly.Account.Persistence.Configurations
{
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnName("Content")
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.ToTable("EmailTemplates");
        }
    }
}