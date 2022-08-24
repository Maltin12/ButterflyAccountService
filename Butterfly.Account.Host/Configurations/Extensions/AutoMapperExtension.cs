using AutoMapper;
using Butterfly.Account.Application.Infrastucture.AutoMapper;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class AutoMapperExtension
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(new[] { typeof(MappingProfile).Assembly });
        }
    }
}
