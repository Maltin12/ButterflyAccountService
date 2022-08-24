using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class DbContextExtension
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AccountDatabase");
            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IAccountDbContext, AccountDbContext>();
        }
    }
}