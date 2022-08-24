using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class SwaggerExtension
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Test API", Version = "v1" });
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new ApiKeyScheme
                {
                    Description = "Provide authentication token",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { JwtBearerDefaults.AuthenticationScheme,Enumerable.Empty<string>() }
                });

            });
        }

        public static void AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
                options.RoutePrefix = null;
            });
        }
    }
}