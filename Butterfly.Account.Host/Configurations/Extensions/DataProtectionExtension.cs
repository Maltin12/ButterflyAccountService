using Microsoft.AspNetCore.DataProtection;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class DataProtectionExtension
    {
        public static void RegisterDataProtection(this IServiceCollection services)
        {
            services.AddDataProtection(options =>
            {
                options.ApplicationDiscriminator = "butterfly";
            }).PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "App_Data")));
        }
    }
}