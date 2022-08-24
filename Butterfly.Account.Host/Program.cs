using Butterfly.Account.Persistence;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using visionagency.Butterfly.Account.Persistence;

namespace Butterfly.Account.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = (AccountDbContext)scope.ServiceProvider.GetRequiredService(typeof(AccountDbContext));

                dbContext.Database.Migrate();

                AccountDbInitializer.Initialize(dbContext);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}