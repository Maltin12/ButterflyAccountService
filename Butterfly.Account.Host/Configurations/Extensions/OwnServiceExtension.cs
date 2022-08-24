using Butterfly.Account.Infrastucture;
using visionagency.Butterfly.Account.Application.Interfaces;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class OwnServiceExtension
    {
        public static void RegisterOwnServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}