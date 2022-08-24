using Butterfly.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Application.Interfaces
{
    public interface IAccountDbContext
    {
        DbSet<EmailTemplate> EmailTemplates { get; set; }
        DbSet<Nationality> Nationalities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<City> Cities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}