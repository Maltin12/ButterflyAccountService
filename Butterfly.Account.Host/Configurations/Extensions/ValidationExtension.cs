using FluentValidation.AspNetCore;
using visionagency.Butterfly.Account.Application.Services.Users.Commands.Add;

namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class ValidationExtension
    {
        public static void UseValidations(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(AddCommandValidation)));
        }
    }
}