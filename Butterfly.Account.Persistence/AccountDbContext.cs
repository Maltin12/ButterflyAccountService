using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Persistence
{
    public class AccountDbContext : IdentityDbContext<User, Role, Guid>, IAccountDbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.Relational().TableName;
                if (table.StartsWith("AspNet"))
                    entityType.Relational().TableName = table.Substring(6);
            }
        }
    }
}