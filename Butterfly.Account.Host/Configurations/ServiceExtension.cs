using Butterfly.Account.Host.Configurations.Extensions;

namespace Butterfly.Account.Host.Configurations
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterAuthentication(configuration);
            services.RegisterAutoMapper();
            services.RegisterDataProtection();
            services.RegisterDbContext(configuration);
            services.RegisterMediator();
            services.RegisterOwnServices();
            services.RegisterSwagger();

            return services;
        }

        public static IMvcBuilder UseServices(this IMvcBuilder builder)
        {
            builder.UseValidations();

            return builder;
        }

        public static IApplicationBuilder AddServices(this IApplicationBuilder app)
        {
            app.AddAuthentication();
            app.AddSwagger();
            return app;
        }
    }
}